using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    [SerializeField]
    public GameObject panelPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Despausar();
            }
            else
            {
                Pausar();
            }
        }
        
    }

    public void Despausar()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pausar()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
