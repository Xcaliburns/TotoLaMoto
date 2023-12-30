using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Character Movements
    public InputAction MoveAction;
    public float speed = 10f;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public InputAction launchAction;

    // character Health

    public int maxHealth = 5;
    int currentHealth;
    public int Health { get { return currentHealth; } }

    //Character isDamaged
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        launchAction.Enable();
        launchAction.performed += Launch;
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;// ceci est un compte à rebours
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + speed * Time.deltaTime * move;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit");
        }



        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        try
        {
            if (UiHandlerNew.Instance != null)
            {
                UiHandlerNew.Instance.SetHealthValue(currentHealth / (float)maxHealth);
            }
            else
            {
                Debug.LogError("Instance de UiHandlerNew introuvable.");
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Une erreur s'est produite lors de la mise à jour de la barre de santé : " + e.Message);
        }

    }

    void Launch(InputAction.CallbackContext context)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        MyProjectile projectile = projectileObject.GetComponent<MyProjectile>();
        projectile.Launch(moveDirection, 300);
        animator.SetTrigger("Launch");
    }



}

