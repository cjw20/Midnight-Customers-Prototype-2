using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    // Fields
    [Tooltip("How far into customer array the player is.")]
    public int customerProgress;
    [Tooltip("Beginning of what day the save was made.")]
    public int day;
    [Tooltip("Progress for each individual customer")]
    public List<int> individualProgress;
    //more variables will be needed eventually

    // References

    public void GetData()
    {
        CustomerManager customerManager = GameObject.FindObjectOfType<CustomerManager>();
        customerProgress = customerManager.arrayPos;
        int i = 0;
        foreach(GameObject customer in customerManager.customerList)
        {
            individualProgress[i] = customer.GetComponent<CustomerInfo>().conversationProgress;
            i++;
        }
        day = GameObject.FindObjectOfType<TimeManager>().day;
    }
}