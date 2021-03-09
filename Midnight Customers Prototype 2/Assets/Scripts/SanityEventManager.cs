using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SanityEventManager : MonoBehaviour
{
    public static SanityEventManager sanityEvents;
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
}
