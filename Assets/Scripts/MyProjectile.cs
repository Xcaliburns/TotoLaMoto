using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectile : MonoBehaviour
{   
   
    Rigidbody2D rigidbody2d;
    Vector2 move;
    float lifetime = 4.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }


    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        MyEnemyController enemy = other.collider.GetComponent<MyEnemyController>();

        if (enemy != null)
        {
            enemy.Fix();
        }
       
        Destroy(gameObject);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MyEnemyController enemy = collision.gameObject.GetComponent<MyEnemyController>();

        if (enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }

}
