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

    //mostrar bot�o
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
        icon.SetActive(true);
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("apertou");
            FindObjectOfType<DialogueElement>().DisplayMessage();
        }
    }


}
