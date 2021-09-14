using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused;
    [SerializeField] GameObject pauseScreen;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {        
            
            TogglePause();

        }

       
    }

    private void TogglePause()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }


       
    }
}
