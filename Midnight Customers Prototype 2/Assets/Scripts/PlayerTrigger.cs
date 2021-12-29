using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // Fields
    bool hasPlacedMop = false;
    bool isBehindCounter = false;
    [Header("Trigger Data")]
    [Tooltip("Not implemented.")]
    public float poopChance = 0.4f; //Currently inert code

    // References
    [Header("Trigger References")]
    [Tooltip("Reference to a Mop Trigger Prefab.")]
    public GameObject mopTriggerPrefab;
    // implement trigger, add behaviors later
    // instantiate at customer location (maybe should put in CustomerMovement)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Register"){
            isBehindCounter=true;
        }
        if (other.tag=="Customer" && !hasPlacedMop && !isBehindCounter){
            float randy = Random.Range(0f,1f);
            //Debug.Log(randy);
            if(randy <= poopChance) {
                // I'm going to leave this commented out
                // Instantiate(mopTriggerPrefab, transform.position, Quaternion.identity);
                // Add oof sfx?
                hasPlacedMop = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Register"){
            isBehindCounter=false;
        }
    }
}