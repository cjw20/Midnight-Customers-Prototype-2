using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalSave
{
    public List<string> saveFileNames;  //list of existing saves
    //make sure it is okay to save as list instead of array

    public void AddSave(string name)
    {
        if (!(saveFileNames.Contains(name)))
        {
            saveFileNames.Add(name);
        }
    }


}
