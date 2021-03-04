using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    public Light2D thisLight; //light this script is referencing
    public float frequency; //how frequently the light should flicker
    public float offDuration; //how long the light should stay off when flickering
    public float offIntensity;
    public float onIntensity;

    float timePassed;
    bool lightOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
