using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if (!hasPlacedMop){
                Instantiate(mopTriggerPrefab, other.transform.position, Quaternion.identity);
                hasPlacedMop = true;
            }
        }
    }

    
    //Get reference to mop prefab
    //implement trigger, add behaviors later
    //instantiate at customer location (maybe should put in CustomerMovement)
    public GameObject mopTriggerPrefab;
    bool hasPlacedMop = false;
}
