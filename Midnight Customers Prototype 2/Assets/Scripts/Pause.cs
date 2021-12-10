using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused;
    [SerializeField] GameObject pauseScreen;

    private PlayerInput playerInput; //asset that has player controls

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (playerInput.Store.Pause.triggered) 
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