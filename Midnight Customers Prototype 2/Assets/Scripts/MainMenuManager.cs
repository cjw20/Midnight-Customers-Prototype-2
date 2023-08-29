using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{  
    [SerializeField] GameObject loadButton;
    [SerializeField] GameObject deleteSaveButton;


    void Awake()
    {
        GlobalSave globalSave = GameControl.control.gameObject.GetComponent<SaveUtility>().GetGlobalSave();
        /*
        if (globalSave.gameComplete)
        {
            //show journal button here!
        }
        */
        if (globalSave == null)
        {
            loadButton.GetComponent<Button>().interactable = false;
            deleteSaveButton.GetComponent<Button>().interactable = false;
        }
        else if (globalSave.gameComplete)
        {
            // TODO
            // Show journal button here
        }
    }   

    public void QuitGame()
    {
        Application.Quit();
    }
}