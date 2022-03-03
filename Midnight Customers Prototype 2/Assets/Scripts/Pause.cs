using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Fields
    [Header("Game Speed")]
    [Tooltip("Whether the game is paused or not.")]
    public bool paused;

    // References
    private PlayerInput playerInput; //asset that has player controls
    [Header("Object References")]
    [Tooltip("Reference to the pause screen prefab.")]
    [SerializeField] GameObject pauseScreen;
    [Tooltip("Reference to the PPManager.")]
    [SerializeField] PPManager ppManager;
    
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

    public void TogglePause()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            ppManager.EnableDepthOfFieldEffect();
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            ppManager.DisableDepthOfFieldEffect();
        }
    }

    public void LoadScene(string sceneName)
    {
        Destroy(GameControl.control.gameObject); //prevents main menu button bugs
        SceneManager.LoadScene(sceneName);
    }
}