using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInfo : MonoBehaviour
{
    public string customerName;
    public Sprite portrait;
    public int relationshipScore; //will need to save and load this for each customer 
    public GameObject[] checkoutItems; //items brought to checkout. May make script to choose this later

    public GameObject[] carriedMoney;

    public DialogueContainer nextConversation;
    public DialogueContainer[] conversations; //list of conversations that customer will progress through
    //may need to split up once conversation variants are added (happy/unhappy)

    public int conversationProgress; //how far into conversations player is. Will want to save this variable somewhere

    public bool hasValidID; //for purchasing items that require ID


    // Start is called before the first frame update
    void Start()
    {
        nextConversation = conversations[conversationProgress]; //may need to put this on load somewhere
    }

   
    public void LoadNextConvo()
    {
        conversationProgress++;

        if(conversationProgress <= conversations.Length - 1)
        {
            nextConversation = conversations[conversationProgress]; //only advances conversation progress if there are still new conversations to load

        }
        
        
    }

    public void UpdateRelationship(int change)
    {
        relationshipScore += change;
    }



    //function that determines what money the customer will pay with later
}
