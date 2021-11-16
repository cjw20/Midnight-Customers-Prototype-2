using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{

    [SerializeField] LightManager lightManager;
    [SerializeField] int eventChance; // % chance that a random event will occur when called 
    public void CallRandomEvent()
    {
        int roll = Random.Range(0, 100);
        if(roll >= eventChance)
        {
            roll = Random.Range(0, 100);

            if(roll >= 60)
            {
                lightManager.PowerOutage(15f); //logic to decide which event would go here
                lightManager.CallLightning();
            }
            else
            {
                lightManager.BreakBulb();
            }
        }
    }
}
