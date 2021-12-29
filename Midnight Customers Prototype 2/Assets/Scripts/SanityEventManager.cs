using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SanityEventManager : MonoBehaviour
{
    // Fields
    bool alreadyTriggered;

    // References
    [Header("Sanity Management")]
    [Tooltip("Reference to a SanityEventManager class instance.")]
    public static SanityEventManager sanityEvents;

    [Header("Sanity Effects")]
    [Tooltip("Reference to a LightSanityEffect class instance.")]
    public LightSanityEffect lightEffects;
    [Tooltip("Lights to be used for sanity effects.")]
    public Light2D[] targetLights;

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

       // StartCoroutine(lightEffects.RedLightScare(targetLights));
    }
}