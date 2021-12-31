using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBulb : MonoBehaviour
{
    // Fields

    // References
    [Header("Bulbs")]
    [Tooltip("Reference to the bulb prefab.")]
    [SerializeField] GameObject newBulb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Base"))
        {
            newBulb.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}