using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;


    private void Start()
    {
        icon.SetActive(false);
    }

    //mostrar botão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("colidiu");
            DisplayText();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icon.SetActive(false);
        }
        
    }


    private void DisplayText()
    {
        Debug.Log("foi");
        icon.SetActive(true);
        Debug.Log("foi denovo");
    }


}
