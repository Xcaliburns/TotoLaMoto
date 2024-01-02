using UnityEngine;

public class MyEnemyController : MonoBehaviour


{

    public float speed;
    public bool vertical;
    public GameObject deathParticles;
    bool aggressive = true;
    public float changeTime = 3.0f;





    // Private variables
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;



    }


    private void FixedUpdate()
    {


        if (!aggressive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y += speed * Time.deltaTime * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);

        }
        else
        {

            position.x += speed * Time.deltaTime * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2d.MovePosition(position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        aggressive = false;

        rigidbody2d.simulated = false;



        Destroy(gameObject);


    }

    private void OnDestroy()
    {

        Instantiate(deathParticles, transform.position, Quaternion.identity);

    }
}
