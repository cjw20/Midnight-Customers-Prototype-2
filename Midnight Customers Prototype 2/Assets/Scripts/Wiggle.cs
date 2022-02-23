using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    [SerializeField] RectTransform wiggleTarget;
    public bool wiggling;
    public float switchTime;

    Vector3 wiggleVector;

    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        wiggleVector = Vector3.forward;
    }

    // Update is called once per frame
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
