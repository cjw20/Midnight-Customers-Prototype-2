using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightSanityEffect : MonoBehaviour
{
    //OLD CLASS DONT USE

    // Fields
    float normalGlobalIntensity;
    Color normalColor;
    [Header("Effect Settings")]
    [Tooltip("Duration of the effect.")]
    public float effectDuration; //separate later when more effects/ Public for testing purposes

    // References
    [Header("Lights")]
    [Tooltip("Lights to be used for unique effects.")]
    public UnityEngine.Rendering.Universal.Light2D[] targetLights; //light that effect will be played on. May need to make array if multiple targets for some effects
    [Tooltip("Light to be used for global effects.")]
    public UnityEngine.Rendering.Universal.Light2D globalLight;

    [Header("Sound")]
    [Tooltip("Reference to a SoundManager class instance.")]
    [SerializeField] SoundManager soundManager;

    void Start()
    {
        normalGlobalIntensity = globalLight.intensity;
    }
   
    /*
    public IEnumerator RedLightScare(Light2D[] targets)
    {
        //makes a light flash red rapidly

        double strobeRate = 0.1;
        Color scaryRed = Color.red; //make new one later?

        globalLight.intensity = 0;

        int i = 0;
        foreach(Light2D light in targets)
        {
            strobeRate += Random.Range(0.0f, 0.01f);
            normalColor = ChangeColor(light, scaryRed); 
            Strobe(light, strobeRate, true);
            i++;
        }
        i = 0;

        soundManager.PauseBGM();
        
        yield return new WaitForSeconds(effectDuration);

        foreach (Light2D light in targets)
        {
            Strobe(light, strobeRate, false);

            ResetLight(light);
            i++;
        }
        
        globalLight.intensity = 1;
        
        soundManager.UnpauseBGM();

        yield break;
    }
    */
}