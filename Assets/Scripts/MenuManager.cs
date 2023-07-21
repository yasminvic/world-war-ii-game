using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField]
    private string[] nameScene;
    public void PlayScene()
    {
        SceneManager.LoadScene(nameScene[0]);
    }

    public void Credits()
    {
        SceneManager.LoadScene(nameScene[1]);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
