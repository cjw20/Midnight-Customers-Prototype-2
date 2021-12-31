using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGame : MonoBehaviour
{
    // Fields

    // References
    MiniGameControl mgControl;

void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
    }
}