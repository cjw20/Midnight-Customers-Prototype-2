using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D[] ceilingLights;
    public Light2D[] windowLights;
    public Light2D globalLight;

    float normalGlobalIntensity;
    Color normalColor;

    // Start is called before the first frame update
    void Start()
    {
        //Strobe(ceilingLights[0], 0.5, 0.2, true); //test call
        normalGlobalIntensity = globalLight.intensity;
        normalColor = globalLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Color ChangeColor(Light2D target, Color newColor)
    {
        //changes a lights color then returns the old one for changing back
        Color targetColor = target.color;
        Color oldColor = targetColor;
        target.color = newColor;

        return oldColor;
    }

    void Strobe(Light2D target, double strobeRate, double offDuration, bool starting)
    {
        //starting = false when turning off strobe effect
        GameObject lightObject = target.gameObject;

        if (starting)
        {
            if (lightObject.GetComponent<LightFlicker>() == null)
            {


                LightFlicker strobeEffect = lightObject.AddComponent<LightFlicker>();
                strobeEffect.offDuration = offDuration;
                strobeEffect.frequency = strobeRate;  
                strobeEffect.offIntensity = 0.2f;
                //strobeEffect.onIntensity = 2;

            }

        }
        if (!starting)
        {

            Destroy(lightObject.GetComponent<LightFlicker>());
            //may want to check if it was a prexisting component and not destroy it if true
        }
    }

    void ResetLight(Light2D target)
    {
        target.color = normalColor;
        target.intensity = 1;
    }
}
