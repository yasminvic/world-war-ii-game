using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    public Animator animator;

    [Header("Delay")]
    [SerializeField]
    public float delayAnimation;

    public void LoadScene()
    {
        StartCoroutine(LoadNextScene());
    }

    public IEnumerator LoadNextScene()
    {
        //acabar animação
        animator.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(delayAnimation);

        //load scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
