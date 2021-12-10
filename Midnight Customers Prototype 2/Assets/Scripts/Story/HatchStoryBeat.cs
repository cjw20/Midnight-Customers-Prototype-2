using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchStoryBeat : MonoBehaviour
{
    [SerializeField] DialogueContainer hatchFound;
    [SerializeField] GameObject investigator;

    [SerializeField] DialogueContainer hatchHint;
    [SerializeField] GameObject hintCustomer;

    [SerializeField] GameObject hatch;
    
    public void StartStory()
    {
        //hintCustomer.GetComponent<CustomerInfo>().SetStoryConvo(hatchHint); //puts hint into customer pool
        hatch.SetActive(true); //makes hatch discoverable
    }

    public void FoundHatch()
    {
        //investigator.GetComponent<CustomerInfo>().SetStoryConvo(hatchFound); //will be able to tell investigator about hatch next time she shows up
    }
}