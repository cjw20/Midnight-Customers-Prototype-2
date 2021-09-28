using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CheckoutTimer : MonoBehaviour
{
    public bool isRunning; //true when timer is active
    public bool inCheckout; //true when checkout open, (update acutal ui element)
    int[] segments;

    int maxValue; //value timer starts at
    int currentMilestone; //index of array for most recently passed milestone 

    public Slider slider;    
    public float timePassed;

    public float scale; //affects how quickly timer counts down
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timePassed += Time.deltaTime * scale;

            if(maxValue - timePassed <= segments[currentMilestone])
            {
                //mood level down
                currentMilestone--;

                if(currentMilestone < 0)
                {
                    currentMilestone = 0; //keeps game from breaking
                    //customer leaves if non essential?
                }
            }

            if (inCheckout)
            {
                slider.value -= Time.deltaTime * scale;
            }
        }
    }


    

    public void StartTimer(CustomerInfo info)
    {
        isRunning = true;
        segments = info.moodMilestones;
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
