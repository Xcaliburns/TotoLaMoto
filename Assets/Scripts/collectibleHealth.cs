using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleHealth : MonoBehaviour


{
    public int amount = 1;

    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.Health < controller.maxHealth)
        {
            controller.ChangeHealth(amount);
            Destroy(gameObject);

        }
    }
}
