using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalSave
{
    // Fields
    [Tooltip("List of existing saves.")]
    public List<string> saveFileNames;
    //make sure it is okay to save as list instead of array

    // References

    public void AddSave(string name)
    {
        if (!(saveFileNames.Contains(name)))
        {
            saveFileNames.Add(name);
        }
    }
}