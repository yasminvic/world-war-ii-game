using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnerObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(spawnerObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
