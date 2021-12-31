using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventHandler : MonoBehaviour
{
    // Fields

    //References
    [Header("Story Events")]
    [Tooltip("Reference to a HatchStoryBeat class instance.")]
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