using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    // Fields
    [Header("Stocking Info")]
    [Tooltip("Whether the shelf is stocked or not.")]
    public bool stocked;
    [Tooltip("The name of the correct item that should be stocked.")]
    public string requiredItem;

    // References
    [Header("Locations")]
    [Tooltip("The location of the target.")]
    public Transform target;
}