using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrigger : MonoBehaviour
{
    MiniGameControl mgControl;
    GameObject first;
    GameObject second;

    bool halfway = false;
    bool done = false;

    //Ice Trigger handles filling the soda machine with ice
    void OnTriggerEnter2D(Collider2D other){
        if (done) {
            mgControl.EndMiniGame();
            Destroy(transform.parent.gameObject); //woah thats dark
        }
        first.SetActive(true);
        if (halfway) {
            second.SetActive(true);
            done = true;
        }
        halfway = true;
    }

    void Start(){
        mgControl = FindObjectOfType<MiniGameControl>();
        first = transform.GetChild(0).gameObject;
        second = transform.GetChild(1).gameObject;
    }
}
