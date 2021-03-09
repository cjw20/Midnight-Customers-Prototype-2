using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSanityEffect : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Light2D[] targetLights; //light that effect will be played on. May need to make array if multiple targets for some effects
    public float effectDuration; //separate later when more effects/ Public for testing purposes
    public Light2D globalLight;

    public AudioSource creepySound; 

    float normalGlobalIntensity;
    Color normalColor;
    
    void Start()
    {
        normalGlobalIntensity = globalLight.intensity;
    }
   

    public IEnumerator RedLightScare(Light2D[] targets)
    {
        //makes a light flash red rapidly

        
        double strobeRate = 0.1;
        Color scaryRed = Color.red; //make new one later?

        globalLight.intensity = 0;

        int i = 0;
        foreach(Light2D light in targets)
        {
            normalColor = ChangeColor(light, scaryRed); 
            Strobe(light, strobeRate, true);
            i++;
        }
        i = 0;


        PlaySound(creepySound);
        soundManager.PauseBGM();
        
        yield return new WaitForSeconds(effectDuration);

        foreach (Light2D light in targets)
        {
            Strobe(light, strobeRate, false);

            ResetLight(light);
            i++;
        }
        
        globalLight.intensity = 1;
        creepySound.Stop();
        soundManager.UnpauseBGM();

        yield break;
    }

    void PlaySound(AudioSource sound)
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
            if(lightObject.GetComponent<LightFlicker>() == null)
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

    void ResetLight(Light2D target)
    {
        target.color = normalColor;
        target.intensity = 1;
    }
}
