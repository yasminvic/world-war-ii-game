using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Delay")]
    [SerializeField]
    private float delay;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Next Scene")]
    [SerializeField]
    private string nameScene;

    private Queue<string> sentences;
    void Start()
    {
        //instanciando
        new WaitForSeconds(0.5f);
        animator.SetBool("IsOpen", true);
        sentences = new Queue<string>();

        //limpando variaveis
        titleText.text = "";
        sentenceText.text = "";
        sentences.Clear();
        

        titleText.text = dialogue.title;

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
