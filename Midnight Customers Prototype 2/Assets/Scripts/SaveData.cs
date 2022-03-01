using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    // Fields
    [Tooltip("How far into custmer array the player is.")]
    public int customerProgress;
    [Tooltip("Beginning of what day the save was made.")]
    public int day;

    //more variables will be needed eventually

    // References

    public void GetData()
    {
        customerProgress = GameObject.FindObjectOfType<CustomerManager>().arrayPos;
        day = GameObject.FindObjectOfType<TimeManager>().day;
    }
}