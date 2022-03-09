using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] SaveUtility saveUtility;

    [SerializeField] GameObject loadButton;
    [SerializeField] GameObject deleteSaveButton;


    void Awake()
    {
        GlobalSave globalSave = saveUtility.GetGlobalSave();
        if (globalSave == null)
        {
            loadButton.SetActive(false);
            deleteSaveButton.SetActive(false);
        }
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}
