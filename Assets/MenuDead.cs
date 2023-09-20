using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDead : MonoBehaviour
{
    [SerializeField]
    private string previousScene;
    public void Retry()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
