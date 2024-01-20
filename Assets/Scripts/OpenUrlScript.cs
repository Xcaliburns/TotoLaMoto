using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrlScript : MonoBehaviour
{
    [SerializeField] string url;
   BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Application.OpenURL(url);
    }
}
