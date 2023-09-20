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
            Debug.Log("nasceu enemy");
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
