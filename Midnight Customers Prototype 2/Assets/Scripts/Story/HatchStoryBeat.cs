using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchStoryBeat : MonoBehaviour
{
    // Fields

    // References
    [Header("Dialogs")]
    [Tooltip("Reference to a DialogueContainer class instance for hatch found dialog.")]
    [SerializeField] DialogueContainer hatchFound;
    [Tooltip("Reference to a DialogueContainer class instance for hatch hint dialog.")]
    [SerializeField] DialogueContainer hatchHint;
    [Tooltip("Reference to the Investigator.")]
    [SerializeField] GameObject investigator;
    [Header("Game Object References")]
    [Tooltip("Reference to the hint customer.")]
    [SerializeField] GameObject hintCustomer;
    [Tooltip("Reference to the hatch object.")]
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