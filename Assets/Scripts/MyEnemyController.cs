using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyController : MonoBehaviour


{

    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    // Private variables
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

   

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y += speed * Time.deltaTime * direction;

        }
        else
        {

            position.x += speed * Time.deltaTime * direction;
        }

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null) 
        {
            player.ChangeHealth(-1);        
        }
    }
}
