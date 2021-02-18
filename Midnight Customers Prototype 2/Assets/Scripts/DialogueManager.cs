using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Conversation conversation; //dialogue to be used in checkout
    int path; //0 for path related to first option, etc. may need to change how this works if branches extend 

    CheckoutManager checkoutManager;
    // Start is called before the first frame update
    void Start()
    {
        checkoutManager = FindObjectOfType<CheckoutManager>();
        //get convo from customer here later
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
