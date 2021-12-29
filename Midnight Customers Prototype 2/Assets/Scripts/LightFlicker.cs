using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    // Fields
    float timePassed;
    bool lightOn = true;
    [Header("Light Flicker Settings")]
    [Tooltip("How frequently the light will flicker.")]
    public double frequency;
    [Tooltip("How long the light stays off during flickering.")]
    public double offDuration;
    [Tooltip("How bright the light is when flickering off.")]
    public float offIntensity;
    [Tooltip("How bright the light is when flickering on.")]
    public float onIntensity;

    // References
    Light2D thisLight; //light this script is referencing

    void Start()
    {
        thisLight = this.GetComponent<Light2D>();
        onIntensity = thisLight.intensity;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= frequency  && lightOn)
        {
            lightOn = false;
            timePassed = 0;
            thisLight.intensity = offIntensity;
        }

        if(timePassed >= offDuration && !lightOn)
        {
            lightOn = true;
            timePassed = 0;
            thisLight.intensity = onIntensity;
        }
    }
}