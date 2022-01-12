using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUtility : MonoBehaviour
{
    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.MCsaves";
        //will need to update to include multiple saves

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData saveData = new SaveData();
        saveData.GetData();

        formatter.Serialize(stream, saveData);
        stream.Close();
    }


    public SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/Game.MCsaves";

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
}
