using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    // Fields
    Vector3 oldPosition;
    Vector3 newPosition;
    [Header("Tool Data")]
    [Tooltip("Whether the tool is cleaning currently or not.")]
    public bool isCleaning;
    [Tooltip("Name of the tool.")]
    public string toolName;
    [Tooltip("The cleaning threshold for the tool.")]
    public float cleaningThreshold;

    // References
    Rigidbody2D rb;
    SoundManager soundmanager;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        oldPosition = rb.position;
        soundmanager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        newPosition = rb.position;
        
        if(newPosition != oldPosition)
        {
            isCleaning = true;
            if (toolName == "Mop")
            {
                soundmanager.PlaySweepingSound();
            }
        }
        else
        {
            isCleaning = false;
            if (toolName == "Mop")
            {
                soundmanager.PauseSweepingSound();
            }
        }
        oldPosition = newPosition;
    }
}