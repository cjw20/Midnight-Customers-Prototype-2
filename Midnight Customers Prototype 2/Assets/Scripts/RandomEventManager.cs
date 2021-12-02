using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{

    [SerializeField] LightManager lightManager;
    [SerializeField] int eventChance; // % chance that a random event will occur when called 
    public bool ongoingLightEvent;
    public void CallRandomEvent()
    {
        int roll = Random.Range(0, 100);
        if(roll >= eventChance)
        {
            CallLightEvent();
                       
        }
    }


    void CallLightEvent()
    {
        if (ongoingLightEvent)
            return;

        ongoingLightEvent = true;
        int roll = Random.Range(0, 100);

        if (roll >= 80)
        {
            lightManager.PowerOutage(15f); //logic to decide which event would go here
            lightManager.CallLightning();
        }
        else if (roll < 80 && roll >= 30)
        {
            lightManager.BreakBulb();
        }
        else
        {
            lightManager.CallLightning();
        }
    }
}
