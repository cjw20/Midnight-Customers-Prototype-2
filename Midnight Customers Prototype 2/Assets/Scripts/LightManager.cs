using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D[] ceilingLights;
    public Light2D[] windowLights;
    public Light2D globalLight;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

    void Strobe(Light2D target, double strobeRate, bool starting)
    {
        GameObject lightObject = target.gameObject;

        if (starting)
        {
            if (lightObject.GetComponent<LightFlicker>() == null)
            {


                LightFlicker strobeEffect = lightObject.AddComponent<LightFlicker>();
                strobeEffect.offDuration = strobeRate;
                strobeEffect.frequency = strobeRate;
                strobeEffect.offIntensity = 0;
                strobeEffect.onIntensity = 2;

            }

        }
        if (!starting)
        {

            Destroy(lightObject.GetComponent<LightFlicker>());
            //may want to check if it was a prexisting component and not destroy it if true
        }
    }
}
