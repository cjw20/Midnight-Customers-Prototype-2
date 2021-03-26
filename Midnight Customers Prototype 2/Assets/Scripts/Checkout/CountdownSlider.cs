using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSlider : MonoBehaviour
{
    public Slider slider;
    public bool isCountingDown;
    public float timePassed;

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
