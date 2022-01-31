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
    [SerializeField] SaveUtility saveUtility;
    public SaveData dataToLoad;
    public int dayProg;
    public int customerProg;
    public bool loadingGame; //true when not new game
    
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
    public void LoadSave(string saveName)
    {
        loadingGame = true;
        SaveData dataToLoad = saveUtility.LoadGame(saveName);
        Debug.Log(dataToLoad.day.ToString());
        Debug.Log(dataToLoad.customerProgress.ToString() + ":)");

        dayProg = dataToLoad.day;
        customerProg = dataToLoad.customerProgress;
        LoadScene("SampleScene"); //load variables from save data once scene has loaded

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            if(dataToLoad != null)
            {
                ContinueGame(dataToLoad);
                Debug.Log("cont");
            }
            Debug.Log("helloooo");
        }
        
    }
    public void ContinueGame(SaveData loadedData)
    {         
        GameObject.FindObjectOfType<CustomerManager>().OnLoadGame(dayProg);
        GameObject.FindObjectOfType<TimeManager>().OnLoadGame(customerProg);
        Debug.Log("contgame");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}