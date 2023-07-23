using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
