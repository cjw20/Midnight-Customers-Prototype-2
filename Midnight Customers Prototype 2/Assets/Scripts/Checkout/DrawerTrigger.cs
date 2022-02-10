using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerTrigger : MonoBehaviour
{
    SpriteRenderer sr; 
    
    void Start(){
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Checkout Item") sr.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Checkout Item") sr.enabled = false;
    }
}
