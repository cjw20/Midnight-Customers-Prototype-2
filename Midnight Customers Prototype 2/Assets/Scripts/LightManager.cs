using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] Light2D[] ceilingLights;
    [SerializeField] Light2D[] miscLights; //fridges, cash register
    [SerializeField] Light2D[] windowLights;
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D flashLight;

    float normalGlobalIntensity;
    Color normalColor;

    [SerializeField] Color lightningColor;
    [SerializeField] AudioSource lightningSound; //currently a placeholder sound effect

    [SerializeField] GameObject powerGameTrigger;
    [SerializeField] GameObject lightBulbTrigger;

    RandomEventManager randomEventManager;

    Light2D brokenLight;
    // Start is called before the first frame update
    void Start()
    {
        randomEventManager = FindObjectOfType<RandomEventManager>();
        //Strobe(ceilingLights[0], 0.5, 0.2, true); //test call

        normalGlobalIntensity = globalLight.intensity;
        normalColor = globalLight.color;

        //PowerOutage(15f);
        //StartCoroutine(LightningEffect());
       // BreakBulb();

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

    public void PowerOutage(float duration)
    {
        foreach(Light2D light in ceilingLights)
        {
            light.gameObject.SetActive(false);
        }
        //StartCoroutine(RestorePower(duration));
        Instantiate(powerGameTrigger);
    }

    public void RestorePower()
    {
        
        //flashLight.gameObject.SetActive(true);  //turns on player flashlight after short delay
        

        foreach (Light2D light in ceilingLights)
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

        foreach (Light2D light in windowLights)
        {
            light.color = lightningColor; //maybe find more specific color later
            light.intensity = 4;
        }
        //play sound effect here! or with delay because sound comes later?
        lightningSound.Play();
        yield return new WaitForSeconds(2f); //duration

        foreach (Light2D light in windowLights)
        {
            light.color = oldColor; //maybe find more specific color later
            light.intensity = oldIntensity;
        }
        randomEventManager.ongoingLightEvent = false;
        yield break;
    }

    void ResetLight(Light2D target)
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
