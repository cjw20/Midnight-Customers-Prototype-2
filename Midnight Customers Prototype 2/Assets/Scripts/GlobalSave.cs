using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalSave
{
    // Fields
    [Tooltip("List of existing saves.")]
    public List<string> saveFileNames;

    [Tooltip("Flag created after game completion.")]
    public bool gameComplete;
    
    // References

    public void AddSave(string name)
    {
        if (!(saveFileNames.Contains(name)))
        {
            saveFileNames.Add(name);
        }
    }


    public void SetComplete()
    {
        gameComplete = true;
        //for unlocking complete journal in main menu
    }
}