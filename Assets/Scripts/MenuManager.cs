using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField]
    private string nameScene;
    public void Play()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
