using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUtility : MonoBehaviour
{
    [SerializeField] GameObject loadWindow;
    [SerializeField] GameObject loadFileButton;

    GlobalSave globalSave;
    public void SaveGame(string saveName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game." + saveName;
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData saveData = new SaveData();
        saveData.GetData();
        formatter.Serialize(stream, saveData);
        stream.Close();
        
        UpdateGlobalSave(saveName);
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

    public void UpdateGlobalSave(string saveName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.GlobalSave";
        FileStream stream = new FileStream(path, FileMode.Create);
        if (!File.Exists(path))
        {
            //only happens first time            
            globalSave = new GlobalSave();
        }
        globalSave.AddSave(saveName);
        formatter.Serialize(stream, globalSave);
        stream.Close();
    }
    public GlobalSave GetGlobalSave()
    {
        string path = Application.persistentDataPath + "/Game.GlobalSave";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GlobalSave data = formatter.Deserialize(stream) as GlobalSave;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }

    public void DisplaySaves()
    {
        globalSave = GetGlobalSave();
        if(globalSave == null)
        {
            //no saves messsage
        }
        Instantiate(loadWindow);

        //get saves from file and display them all as buttons
        
    }
}
