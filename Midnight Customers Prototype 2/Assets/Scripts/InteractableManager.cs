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
    string[] freezer_m = new string[] { "Why do we sell so much water?", "I've never heard of these brands.", "Is there a distributor monopoly or something? None of these look good." };
    string[] freezer_l = new string[] { "Who drinks salt water?", "It smells like the sea in there.", "Is that handprint...webbed?" };
    string[] soda_m = new string[] { "There's so much mold...", "There's no way I'm cleaning this." };
    string[] soda_l = new string[] { "Oh good, an option for salt water.", "I'd rather be dehydrated I think." };
    string[] window_m = new string[] { "I feel like something's watching me...", "There's not a single streetlight huh...", "How do people find this place?" };
    string[] window_l = new string[] { "Please be a normal night... for once.", "Someone's hiding out there...", "I swear some of these people wander out of the woods." };
    string[] shelves_m = new string[] { "The packaging is wet... gross.", "I'm going to beg management to sell something normal for once.", "These are some interesting flavors." };
    string[] shelves_l = new string[] { "A whole fish is labeled as cat food...", "Lots of worms... I'm just going to assume it's for fishing.", "I'll throw up right here." };
    string[] food_m = new string[] { "This stuff is so burnt.", "Is that how those are supposed to look?", "It's so dry. It'd probably turn to ash if I touch it." };
    string[] food_l = new string[] { "Tentacles... on a stick. At this point sure, why not.", "Ingedients... ground eyeballs. Huh?", "1,000 grams feels like more than enough protein." };
    
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
