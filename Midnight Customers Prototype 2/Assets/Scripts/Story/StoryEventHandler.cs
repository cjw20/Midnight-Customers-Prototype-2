using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventHandler : MonoBehaviour
{
    [SerializeField] HatchStoryBeat hatchStory;

    public void DayEvents(int day)
    {
        switch (day)
        {
            case 4:
                hatchStory.StartStory();
                break;
            default:
                break;

                //add more days or make cleaner later
        }
    }
}