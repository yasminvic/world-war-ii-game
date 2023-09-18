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
            DisplayText();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.SetActive(false);
    }


    private void DisplayText()
    {
        icon.SetActive(true);
    }


}
