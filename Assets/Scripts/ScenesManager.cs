using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private string nameScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}
