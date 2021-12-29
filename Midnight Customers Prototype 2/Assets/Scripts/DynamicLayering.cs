using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLayering : MonoBehaviour
{
    // Fields
    [Header("Layers")]
    [Tooltip("Target layer for player and customers.")]
    public int targetLayer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Customer"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = targetLayer;
        }
    }
}