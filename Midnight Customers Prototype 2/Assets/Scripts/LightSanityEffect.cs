using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSanityEffect : MonoBehaviour
{
    public Light2D targetLight; //light that effect will be played on. May need to make array if multiple targets for some effects
    public float effectDuration; //separate later when more effects/ Public for testing purposes

    float normalIntensity;
    Color normalColor;
    
   
   

    public IEnumerator RedLightScare(Light2D target)
    {
        //makes a light flash red rapidly

        
        double strobeRate = 0.1;
        Color scaryRed = Color.red; //make new one later?
        normalColor = ChangeColor(target, scaryRed);
        Strobe(target, strobeRate, true);

        yield return new WaitForSeconds(effectDuration);

        
        Strobe(target, strobeRate, false);

        ResetLight(target);

       

        yield break;
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
        normalIntensity = target.intensity;
        if (starting)
        {
            if(lightObject.GetComponent<LightFlicker>() == null)
            {
                LightFlicker strobeEffect = lightObject.AddComponent<LightFlicker>();
                strobeEffect.offDuration = strobeRate;
                strobeEffect.frequency = strobeRate;
                strobeEffect.offIntensity = 0;
                strobeEffect.onIntensity = 1;
                
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
