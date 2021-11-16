using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGame : MonoBehaviour
{
    MiniGameControl mgControl;
void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
    }
}
