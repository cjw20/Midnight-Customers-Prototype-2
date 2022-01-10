using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSlider : MonoBehaviour
{
    // Fields
    [Header("Data")]
    [Tooltip("Whether timer is counting or not.")]
    public bool isCountingDown;
    [Tooltip("How much time has passed on the timer.")]
    public float timePassed;

    // References
    [Header("References")]
    [Tooltip("Reference to the time slider.")]
    public Slider slider;
    
    public void SetValue(float change)
    {
        slider.value += change;
    }

    public void SetMinMax(float min, float max, float current)
    {
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = current;
    }

    private void Update()
    {
        if (isCountingDown)
        {
            timePassed += Time.deltaTime;
            if(timePassed >= 0.01f)
            {
                SetValue(-timePassed);
                timePassed = 0;
                //if value = 0, tell dialogue player?
            }
        }
    }

    public void StartCount()
    {
        isCountingDown = true;
    }

    public void Reset()
    {
        slider.value = slider.maxValue;
        isCountingDown = false;
    }
}