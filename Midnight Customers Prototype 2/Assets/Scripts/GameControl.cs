using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Fields

    // References
    [Header("References")]
    [Tooltip("Reference to a GameControl class instance.")]
    public static GameControl control;

    /*
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);  //makes sure there is only one game control in scene. 
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);  
        }
    }
    */

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}