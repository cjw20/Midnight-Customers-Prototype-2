using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public int customerProgress; //how far into customer array player is
    public int day; //beginning of what day the save was made

    //more variables will be needed eventually
    public void GetData()
    {
        customerProgress = GameObject.FindObjectOfType<CustomerManager>().arrayPos;
        day = GameObject.FindObjectOfType<TimeManager>().day;
    }
}
