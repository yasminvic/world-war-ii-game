using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerCutScene : MonoBehaviour
{
    [Header("Dialogo")]
    [SerializeField]
    private Dialogue dialogue;

    [Header("Game Object")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI sentenceText;
    [SerializeField]
    private GameObject continueButton;
    [SerializeField]
    private Image background;

    [Header("Delay")]
    [SerializeField]
    private float delay;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Images")]
    [SerializeField]
    private ImagePath imgPath;

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

    private Queue<string> sentences;
    private Queue<string> images;
    private AudioSource audioSource;
    void Start()
    {
        //instanciando
        new WaitForSeconds(0.5f);
        animator.SetBool("IsOpen", true);
        sentences = new Queue<string>();
        images = new Queue<string>();
        audioSource = this.gameObject.AddComponent<AudioSource>();

        //limpando variaveis
        titleText.text = "";
        sentenceText.text = "";
        sentences.Clear();
        images.Clear();
        

        titleText.text = dialogue.title;

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (var image in imgPath.images)
        {
            images.Enqueue(image);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        string img = images.Dequeue();

        background.sprite = Resources.Load<Sprite>($"{imgPath.path}/{img}");

        StopAllCoroutines();
        audioSource.Stop();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentenceText.text = "";

        for (int i = 0; i < sentence.Length; i++)
        {
            if (i % delayTypeAudio == 0)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.volume = volume;
                audioSource.PlayOneShot(typeAudio);
            }
            sentenceText.text += sentence[i];

         
            yield return new WaitForSeconds(delay);

          
        }
    }

    void EndDialogue()
    {
        StopAllCoroutines();
        animator.SetBool("IsOpen", false);
        FindObjectOfType<LevelLoader>().LoadScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            EndDialogue();
        }
    }
}
