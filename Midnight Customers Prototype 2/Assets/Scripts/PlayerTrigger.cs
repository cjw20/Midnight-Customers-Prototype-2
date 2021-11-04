using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    
    //Get reference to mop prefab
    //implement trigger, add behaviors later
    //instantiate at customer location (maybe should put in CustomerMovement)
    public GameObject mopTriggerPrefab;
    bool hasPlacedMop = false;
    bool isBehindCounter = false;
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag=="Register"){
            isBehindCounter=true;
        }
        if (other.tag=="Customer" && !hasPlacedMop && !isBehindCounter){
            Instantiate(mopTriggerPrefab, transform.position, Quaternion.identity);
            //Add oof sfx?
            hasPlacedMop = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.tag=="Register"){
            isBehindCounter=false;
        }
    }
}
