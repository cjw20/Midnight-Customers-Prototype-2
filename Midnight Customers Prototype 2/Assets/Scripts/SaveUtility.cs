using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUtility : MonoBehaviour
{
    [SerializeField] GameObject loadWindow;
    [SerializeField] GameObject loadFileButton;

    [SerializeField] GlobalSave globalSave;
    public void SaveGame(string saveName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game." + saveName;
        globalSave.AddSave(saveName);

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData saveData = new SaveData();
        saveData.GetData();

        formatter.Serialize(stream, saveData);
        stream.Close();
    }


    public SaveData LoadGame(string saveName)
    {
        string path = Application.persistentDataPath + "/Game." + saveName;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }

    public void UpdateGlobalSave()
    {

    }
    public void GetGlobalSave()
    {

    }

    public void DisplaySaves()
    {
        Instantiate(loadWindow);

        //get saves from file and display them all as buttons
        
    }
}
