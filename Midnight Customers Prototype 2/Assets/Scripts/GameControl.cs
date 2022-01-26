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
    SaveData dataToLoad;
    
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
        SaveData dataToLoad = saveUtility.LoadGame(saveName);
        LoadScene("SampleScene"); //load variables from save data once scene has loaded

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            if(dataToLoad != null)
            {
                ContinueGame(dataToLoad);
            }
        }
    }
    public void ContinueGame(SaveData loadedData)
    {         
        GameObject.FindObjectOfType<CustomerManager>().OnLoadGame(loadedData.customerProgress);
        GameObject.FindObjectOfType<TimeManager>().OnLoadGame(loadedData.day);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}