using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueElement : MonoBehaviour
{
    [SerializeField]
    private Dialogue message;

    [Header("Game Objects")]
    [SerializeField]
    private TextMeshProUGUI titleObject;
    [SerializeField]
    private TextMeshProUGUI messageObject;
    [SerializeField]
    private GameObject panel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip typeAudio;
    [Range(0f, 1f)]
    [SerializeField]
    private float volume = 0.2f;
    [SerializeField]
    private int delayTypeAudio;
    [Range(-3, 3)]
    [SerializeField]
    private float minPitch;
    [Range(-3, 3)]
    [SerializeField]
    private float maxPitch;
    [SerializeField]
    private float delayType;

    private Queue<string> messages;
    private AudioSource audioSource;

    void Start()
    {
        //instanciando
        messages = new Queue<string>();
        audioSource = this.gameObject.AddComponent<AudioSource>();
        titleObject.text = message.title;

        //limpando variaveis
        messageObject.text = "";
        messages.Clear();
        
        //Tornando invisível
        panel.SetActive(false);

        foreach (var message in message.sentences)
        {
            messages.Enqueue(message);
        }
    }
     
    public void DisplayMessage()
    {
        Debug.Log("clicou");
        panel.SetActive(true);
        string textOnScreen = messages.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(textOnScreen));
    }
  
    IEnumerator TypeSentence(string textOnScreen)
    {
        messageObject.text = "";

        for (int i = 0; i < textOnScreen.Length; i++)
        {
            if (i % delayTypeAudio == 0)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.volume = volume;
                audioSource.PlayOneShot(typeAudio);
                //yield return new WaitForSeconds(delay);
            }
            messageObject.text += textOnScreen[i];


            yield return new WaitForSeconds(delayType);


        }
    }
}
