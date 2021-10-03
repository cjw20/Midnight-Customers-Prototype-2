using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventHandler : MonoBehaviour
{

    [SerializeField] HatchStoryBeat hatchStory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
