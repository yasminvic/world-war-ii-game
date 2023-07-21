using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
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
    private Image background;

    [Header("Delay")]
    [SerializeField]
    private float delay;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Next Scene")]
    [SerializeField]
    private string nameScene;

    [Header("Images")]
    [SerializeField]
    private ImagePath imgPath;

    private Queue<string> sentences;
    private Queue<string> images;
    void Start()
    {
        //instanciando
        new WaitForSeconds(0.5f);
        animator.SetBool("IsOpen", true);
        sentences = new Queue<string>();
        images = new Queue<string>();

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
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentenceText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            sentenceText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        SceneManager.LoadScene(nameScene);
    }
}
