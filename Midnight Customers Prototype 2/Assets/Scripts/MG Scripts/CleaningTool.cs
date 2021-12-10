using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    public bool isCleaning;
    public string toolName;
    
    public float cleaningThreshold;

    Vector3 oldPosition;
    Vector3 newPosition;
    Rigidbody2D rb;
    SoundManager soundmanager;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        oldPosition = rb.position;
        soundmanager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
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