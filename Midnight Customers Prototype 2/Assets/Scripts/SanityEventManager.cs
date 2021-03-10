using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SanityEventManager : MonoBehaviour
{
    public static SanityEventManager sanityEvents;
    public LightSanityEffect lightEffects;
    public Light2D[] targetLights;
    bool alreadyTriggered;
    void Awake()
    {
        if (sanityEvents == null)
        {
            DontDestroyOnLoad(gameObject); 
        }
        else if (sanityEvents != this)
        {
            Destroy(gameObject);
        }
    }
    

    public void LightEffect()
    {
        //logic for choosing effect here

        StartCoroutine(lightEffects.RedLightScare(targetLights));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyTriggered)
        {
            LightEffect();
            //this is placeholder for testing
            alreadyTriggered = true;
        }

    }
}
