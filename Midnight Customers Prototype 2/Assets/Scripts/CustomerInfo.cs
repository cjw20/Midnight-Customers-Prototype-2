using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerInfo : MonoBehaviour
{
    // Fields
    [Header("Customer Information")]
    [Tooltip("Customer name.")]
    public string customerName;
    [Tooltip("Current relationship score the player has with this character.")]
    public int relationshipScore; //will need to save and load this for each customer
    [Tooltip("Whether the character has a valid ID or not.")]
    public bool hasValidID;
    [Tooltip("Set to true if the character should NOT leave when the timer runs out.")]
    public bool essential;
    [Tooltip("How far the player is into the conversations with this character.")]
    public int conversationProgress; //how far into conversations player is. Will want to save this variable somewhere
    [Tooltip("Determines how to segment the mood timer.")]
    [Range(0, 100)]
    public int[] moodMilestones; //how to segment mood timer (100 max, 0 min) timer counts down from 100

    // References
    [Header("Customer Data")]
    [Tooltip("Font to use for this customer.")]
    public Font dialogueFont; //font customer will use
    [Tooltip("Sprite to use for this customer.")]
    public Sprite portrait;
    [Tooltip("Objects this character will bring to the checkout counter.")]
    public GameObject[] checkoutItems; //items brought to checkout. May make script to choose this later
    [Tooltip("The amount of money carried by this character.")]
    public GameObject[] carriedMoney;
    [Tooltip("Next conversation that this character will have next.")]
    public DialogueContainer nextConversation;
    [Tooltip("All conversations this character will progress through.")]
    public DialogueContainer[] conversations; //may need to split up once conversation variants are added (happy/unhappy)

    void Start()
    {
        if(nextConversation == null)
        {
            nextConversation = conversations[conversationProgress]; //only assigns when empty so that story convos arent over written when customer enters store
        }
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

    public void SetStoryConvo(DialogueContainer convo)
    {
        if(conversationProgress > 0)
        {
            conversationProgress--; //moves conversation progress back so that after checkout it will go back to where it was
        }
        nextConversation = convo;
    }
    //function that determines what money the customer will pay with later
}