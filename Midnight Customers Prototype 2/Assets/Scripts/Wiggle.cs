using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    // Fields
    [Tooltip("Whether object is wiggling or not.")]
    public bool wiggling;
    [Tooltip("How long to wiggle before switching wiggle vector.")]
    public float switchTime;
    float timePassed;

    // Refernces
    Vector3 wiggleVector;
    [Tooltip("Reference to the RectTransform to wiggle.")]
    [SerializeField] RectTransform wiggleTarget;

    void Start()
    {
        wiggleVector = Vector3.forward;
    }

    void Update()
    {
        if (wiggling)
        {
            wiggleTarget.Rotate(wiggleVector);
        }

        timePassed += Time.deltaTime;
        if(timePassed > switchTime)
        {
            timePassed = 0;
            wiggleVector *= -1;
        }
    }
}