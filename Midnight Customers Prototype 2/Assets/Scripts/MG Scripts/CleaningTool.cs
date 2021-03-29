using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    public bool isCleaning;
    
    public float cleaningThreshold;

    Vector3 oldPosition;
    Vector3 newPosition;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        oldPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = rb.position;
        
        if(newPosition != oldPosition)
        {
            isCleaning = true;
        }
        else
        {
            isCleaning = false;
        }
        oldPosition = newPosition;
    }
}
