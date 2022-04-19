using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    //Referenced by TimeManager
    //Static Lists of Strings
    //Get Text Objects
    //Method called by TimeManager, provides day, sets corresponding interactable texts
    // Fields
    string[] freezer_m = new string[] { "Why do we sell so much water?", "What kind of brand is this?", "Someone drew the investigator in the frost." };
    string[] freezer_l = new string[] { "Who drinks saltwater?", "Why is everything so sticky?", "Someone drew a fish person in the frost." };
    string[] soda_m = new string[] { "Salt water in a drink machine.", "Who refills the machine?" };
    string[] soda_l = new string[] { "I think mold is growing in the ice machine.", "Glad I haven't been asked to clean this." };
    string[] window_m = new string[] { "Is that something moving in the woods?", "It is really creepy with no lights out there", "How do people find this place" };
    string[] window_l = new string[] { "What is that?", "Who is that in the woods?", "Where do these people come from?" };
    string[] shelves_m = new string[] { "Why do we sell more of the unnatural things?", "We never sell the normal items.", "These are some interesting flavors." };
    string[] shelves_l = new string[] { "Why do we have eel flavored cat food?", "Did that gummy worm move?", "Who buys this stuff..." };
    string[] food_m = new string[] { "This stuff is burnt.", "Is that how those are supposed to look?" };
    string[] food_l = new string[] { "Is that a tentacle...", "Does that say eyeballs as an ingredient?" };
    
    // References
    Interactable freezer_reference;
    Interactable soda_reference;
    Interactable shelves_reference;
    Interactable window_reference;
    Interactable food_reference;

    void Start(){
        food_reference = transform.GetChild(0).GetComponent<Interactable>();
        soda_reference = transform.GetChild(1).GetComponent<Interactable>();
        shelves_reference = transform.GetChild(2).GetComponent<Interactable>();
        freezer_reference = transform.GetChild(4).GetComponent<Interactable>();
        window_reference = transform.GetChild(5).GetComponent<Interactable>();
    }


    public void UpdateInteractables(int day){
        if (day == 3){
            food_reference.SetMessage(food_m);
            soda_reference.SetMessage(soda_m);
            shelves_reference.SetMessage(shelves_m);
            window_reference.SetMessage(window_m);
            freezer_reference.SetMessage(freezer_m);
        }
        if (day == 6){
            food_reference.SetMessage(food_l);
            soda_reference.SetMessage(soda_l);
            shelves_reference.SetMessage(shelves_l);
            window_reference.SetMessage(window_l);
            freezer_reference.SetMessage(freezer_l);
        }
    }
}
