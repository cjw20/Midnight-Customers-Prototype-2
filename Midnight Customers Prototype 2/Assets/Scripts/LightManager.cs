using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{
    // Fields
    float normalGlobalIntensity;
    Color normalColor;

    // References
    RandomEventManager randomEventManager;
    UnityEngine.Rendering.Universal.Light2D brokenLight;
    [Header("Scene Lights")]
    [Tooltip("Ceiling lights.")]
    [SerializeField] UnityEngine.Rendering.Universal.Light2D[] ceilingLights;
    [Tooltip("Misc lights.")]
    [SerializeField] UnityEngine.Rendering.Universal.Light2D[] miscLights; //fridges, cash register
    [Tooltip("Window lights.")]
    [SerializeField] UnityEngine.Rendering.Universal.Light2D[] windowLights;
    [Tooltip("Global light.")]
    [SerializeField] UnityEngine.Rendering.Universal.Light2D globalLight;
    [Tooltip("Player flashlight light.")]
    [SerializeField] UnityEngine.Rendering.Universal.Light2D flashLight;

    [Header("Lightning")]
    [Tooltip("Lightning color.")]
    [SerializeField] Color lightningColor;
    [Tooltip("Lightning sound effect.")]
    [SerializeField] AudioSource lightningSound; //currently a placeholder sound effect

    [Header("Triggers")]
    [Tooltip("Trigger to start the power minigame.")]
    [SerializeField] GameObject powerGameTrigger;
    [Tooltip("Trigger to start the light bulb minigame.")]
    [SerializeField] GameObject lightBulbTrigger;

    void Start()
    {
        randomEventManager = FindObjectOfType<RandomEventManager>();
        //Strobe(ceilingLights[0], 0.5, 0.2, true); //test call

        normalGlobalIntensity = globalLight.intensity;
        normalColor = globalLight.color;

        // PowerOutage(15f);
        // StartCoroutine(LightningEffect());
        // BreakBulb();
    }

    Color ChangeColor(UnityEngine.Rendering.Universal.Light2D target, Color newColor)
    {
        //changes a lights color then returns the old one for changing back
        Color targetColor = target.color;
        Color oldColor = targetColor;
        target.color = newColor;

        return oldColor;
    }

    void Strobe(UnityEngine.Rendering.Universal.Light2D target, double strobeRate, double offDuration, bool starting)
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

    public void PowerOutage(float duration)
    {
        foreach(UnityEngine.Rendering.Universal.Light2D light in ceilingLights)
        {
            light.gameObject.SetActive(false);
        }
        //StartCoroutine(RestorePower(duration));
        Instantiate(powerGameTrigger);
    }

    public void RestorePower()
    {
        //flashLight.gameObject.SetActive(true);  //turns on player flashlight after short delay
        
        foreach (UnityEngine.Rendering.Universal.Light2D light in ceilingLights)
        {
            light.gameObject.SetActive(true);
        }
        //flashLight.gameObject.SetActive(false); not needed since flashlight has own toggle
        randomEventManager.ongoingLightEvent = false;
    }

    public void CallLightning()
    {
        StartCoroutine(LightningEffect());
    }

    IEnumerator LightningEffect()
    {
        Color oldColor = windowLights[0].color; //saves color for after light effect
        float oldIntensity = windowLights[0].intensity;
        
        yield return new WaitForSeconds(3f); //start delay, probably not neccessary

        foreach (UnityEngine.Rendering.Universal.Light2D light in windowLights)
        {
            light.color = lightningColor; //maybe find more specific color later
            light.intensity = 4;
        }
        //play sound effect here! or with delay because sound comes later?
        lightningSound.Play();
        yield return new WaitForSeconds(2f); //duration

        foreach (UnityEngine.Rendering.Universal.Light2D light in windowLights)
        {
            light.color = oldColor; //maybe find more specific color later
            light.intensity = oldIntensity;
        }
        randomEventManager.ongoingLightEvent = false;
        yield break;
    }

    void ResetLight(UnityEngine.Rendering.Universal.Light2D target)
    {
        target.color = normalColor;
        target.intensity = 1;
    }

    public void BreakBulb()
    {
        if (brokenLight != null)
        {
            return; //keeps multiple bulbs from breaking at once
        }
        int bulbNum = Random.Range(0, ceilingLights.Length - 1);

        ceilingLights[bulbNum].enabled = false;
        Instantiate(lightBulbTrigger, ceilingLights[bulbNum].gameObject.transform);
        brokenLight = ceilingLights[bulbNum];
        //lightBulbTrigger.transform.position = ceilingLights[bulbNum].gameObject.transform.position;
    }

    public void FixBulb()
    {
        brokenLight.enabled = true;
        brokenLight = null;
        randomEventManager.ongoingLightEvent = false;
        //will need to store multiple if somehow multiple bulbs are broken
    }
}