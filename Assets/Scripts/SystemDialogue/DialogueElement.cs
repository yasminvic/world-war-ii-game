using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueElement : MonoBehaviour
{
    [SerializeField]
    private Dialogue message;

    [SerializeField]
    private TextMeshProUGUI titleObject;
    [SerializeField]
    private TextMeshProUGUI messageObject;

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
    private float delay;

    private Queue<string> messages;
    private AudioSource audioSource;

    void Start()
    {
        //instanciando
        messages = new Queue<string>();
        audioSource = this.gameObject.AddComponent<AudioSource>();

        //limpando variaveis
        messageObject.text = "";
        messages.Clear();


        titleObject.text = message.title;

        foreach (var message in message.sentences)
        {
            messages.Enqueue(message);
        }

        DisplayMessage();
    }
     
    void DisplayMessage()
    {
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


            yield return new WaitForSeconds(delay);


        }
    }
}
