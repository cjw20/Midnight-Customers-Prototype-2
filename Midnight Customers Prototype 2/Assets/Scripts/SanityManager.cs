using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    // Fields
    [Header("Stress and Sanity")]
    [Tooltip("Maximum stress limit.")]
    public int maxStress;
    [Tooltip("Current stress amount.")]
    public int currentStress;
    [Tooltip("Current sanity amount. (Higher numbers means more insane)")]
    public int currentSanity;
    [Tooltip("Excess change that stress did not block.")]
    int excessLoss;

    // References
    [Header("UI References")]
    [Tooltip("Text to show current stress.")]
    public Text stressText;
    [Tooltip("Text to show current sanity.")]
    public Text sanityText;

    void Start()
    {
        currentStress = maxStress; //only if loaded  for first time
        //will need to make static like game control or store values in it if changing scenes later

        UpdateSanityUI();
    }

    public void UpdateSanity(int change)
    {
        //updates stress sanity by change value - if losing, + if gaining
        excessLoss = currentStress + change;

        if(excessLoss >= currentStress) //true when stress is being restored
        {
            currentStress = excessLoss;
            if(currentStress > maxStress)
            {
                currentStress = maxStress; //makes sure stress doesn't exceed max value
            }
        }
        else
        {
            currentStress += change;

            if(excessLoss > 0)
            {
                currentSanity -= excessLoss; //only changes sanity if stress buffer wasn't enough
            }
            
            if (currentStress < 0)
            {
                currentStress = 0; //stress can not be below 0
            }
        }
        UpdateSanityUI();
    }

    public void UpdateSanityUI()
    {
       // sanityText.text = "Current Sanity: " + currentSanity;
       // stressText.text = "Current Stress: " + currentStress;
    }
}