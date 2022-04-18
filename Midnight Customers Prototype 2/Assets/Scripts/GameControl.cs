using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
    // Fields
    [Tooltip("Day progression.")]
    public int dayProg;
    [Tooltip("Customer progression.")]
    public int customerProg;
    public List<int> individualProg;
    [Tooltip("Whether the game has been loaded from a previous save or not. (True when NOT a new game.)")]
    public bool loadingGame;

    public bool gameComplete;

    // References
    [Header("References")]
    [Tooltip("Reference to a GameControl class instance.")]
    public static GameControl control;
    [Tooltip("Reference to a SaveUtility class instance.")]
    [SerializeField] SaveUtility saveUtility;
    [Tooltip("Reference to SaveData to be loaded.")]
    public SaveData dataToLoad;
    
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public void SaveGame(string saveName)
    {
        saveUtility.SaveGame(saveName);
    }
    public void SetComplete()
    {
        gameComplete = true;
        saveUtility.UpdateGlobalSave("Manual Save");
    }
    public void LoadSave(string saveName)
    {
        loadingGame = true;
        SaveData dataToLoad = saveUtility.LoadGame(saveName);
        dayProg = dataToLoad.day;
        customerProg = dataToLoad.customerProgress;
        individualProg = dataToLoad.individualProgress;
        LoadScene("SampleScene"); //load variables from save data once scene has loaded
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            if(dayProg != 0)
            {
                ContinueGame();               
            }            
        }        
    }
    public void ContinueGame()
    {         
        GameObject.FindObjectOfType<CustomerManager>().OnLoadGame(customerProg, individualProg);
        GameObject.FindObjectOfType<TimeManager>().OnLoadGame(dayProg);        
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}