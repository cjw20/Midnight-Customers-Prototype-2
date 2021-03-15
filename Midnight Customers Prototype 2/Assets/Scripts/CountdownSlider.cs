using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSlider : MonoBehaviour
{
    public Slider slider;
    bool isCountingDown;

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
        if (isCountingDown && slider.value > 0)
        {
            SetValue(-Time.deltaTime);
            //if value = 0, tell dialogue player?
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
