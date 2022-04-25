using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{  
    [SerializeField] GameObject loadButton;
    [SerializeField] GameObject deleteSaveButton;


    void Awake()
    {
        GlobalSave globalSave = GameControl.control.gameObject.GetComponent<SaveUtility>().GetGlobalSave();

        if (globalSave.gameComplete)
        {
            //show journal button here!
        }
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
