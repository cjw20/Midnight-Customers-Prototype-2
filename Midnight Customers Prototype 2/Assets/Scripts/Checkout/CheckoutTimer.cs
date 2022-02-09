using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CheckoutTimer : MonoBehaviour
{
    // Fields
    int[] segments;
    int maxValue; //value timer starts at
    [Header("Timer Data")]
    [Tooltip("Whether the timer is active or not.")]
    public bool isRunning; //true when timer is active
    [Tooltip("Whether checkout is open or not.")]
    public bool inCheckout; //true when checkout open, (update acutal ui element)
    [Tooltip("How much time has passed.")]
    public float timePassed;
    [Tooltip("How quickly the timer counts down.")]
    public float scale; //affects how quickly timer counts down
    [Tooltip("Index of the array for the most recently passed milestone.")]
    [SerializeField] int currentMilestone; //index of array for most recently passed milestone

    // References
    CustomerInfo currentCustomer;
    [Header("References")]
    [Tooltip("Reference to the time slider.")]
    public Slider slider;
    
    [Tooltip("Reference to the image within the time slider.")]
    public Image slideImage;
    
    [Tooltip("Reference to a CheckoutManager class instance.")]
    [SerializeField] CheckoutManager checkoutManager;

    void Update()
    {
        if (isRunning)
        {
            timePassed += Time.deltaTime * scale;

            if(maxValue - timePassed <= segments[currentMilestone])
            {
                //mood level down
                currentMilestone--;
                SetMood();

                if(currentMilestone < 0)
                {
                    currentMilestone = 0; //keeps game from breaking
                    if (!currentCustomer.essential)
                    {
                        if (inCheckout)
                        {
                            checkoutManager.GiveUp();
                        }

                        else
                        {
                            currentCustomer.gameObject.GetComponent<CustomerMovement>().FinishedCheckout(); //tells customer to leave checkout area. may need to revert conversation progress?
                        }

                        ResetTimer();
                        return;
                        //leave!
                    }
                }
            }
            if (inCheckout)
            {
                slider.value -= Time.deltaTime * scale;
            }
        }
    }

    void SetMood()
    {
        switch (currentMilestone + 1)
        {
            case 3:
                currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("happy");
                slideImage.color = new Color(255f, 0f, 0f, 255f);
                break;
            case 2:
                currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("sad");
                slideImage.color = new Color(200f, 0f, 0f, 255f);
                break;
            case 1:
                currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("angry");
                slideImage.color = new Color(150f, 0f, 0f, 255f);
                break;
            case 0:
                currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("pissed");
                slideImage.color = new Color(100f, 0f, 0f, 255f);
                break;
            default:
                currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("happy");
                slideImage.color = Color.white;
                break;
        }
    }

    public void StartTimer(CustomerInfo info)
    {
        isRunning = true;
        segments = info.moodMilestones;
        currentCustomer = info;
        currentCustomer.GetComponentInChildren<MoodIndicator>().SetMood("happy");
        maxValue = segments.Max(); //gets highest value from array

        SetValues();
        currentMilestone = segments.Length - 2; //gets index of value 1 behind max
    }

    void SetValues()
    {
        slider.maxValue = maxValue;
        slider.minValue = 0;
        slider.value = maxValue;
    }

    public void UpdateValue(float change)
    {
        slider.value += change;
        //for use of changing value up or down if action make customer happy/unhappy
    }

    public void ResetTimer()
    {
        timePassed = 0;
        isRunning = false;
        inCheckout = false;
        segments = null;
    }
}