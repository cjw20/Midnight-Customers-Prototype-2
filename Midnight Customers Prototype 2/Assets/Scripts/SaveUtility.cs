using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveUtility : MonoBehaviour
{
    [SerializeField] GameObject loadWindowPrefab;
    [SerializeField] GameObject loadFileButtonPrefab;

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
        globalSave = new GlobalSave();
        globalSave.saveFileNames = new List<string>();
        if (!File.Exists(path))
        {
            //only happens first time            
            globalSave = new GlobalSave();
            globalSave.saveFileNames = new List<string>(); //if statement not working
        }
        FileStream stream = new FileStream(path, FileMode.Create);
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
            return;
        }
        GameObject canvas = GameObject.Find("Canvas");
        GameObject loadWindow = Instantiate(loadWindowPrefab, canvas.transform);
        foreach(string saveName in globalSave.saveFileNames)
        {
            GameObject newButton = Instantiate(loadFileButtonPrefab, loadWindow.transform);
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(delegate { GameControl.control.LoadSave(saveName); }); //vertical layout group should organize position of buttons
            button.GetComponentInChildren<Text>().text = saveName; //maybe change what gets displayed 
        }
        //get saves from file and display them all as buttons
        
    }
}
