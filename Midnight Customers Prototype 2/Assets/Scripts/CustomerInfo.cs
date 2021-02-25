using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInfo : MonoBehaviour
{
    public string customerName;
    public GameObject[] checkoutItems; //items brought to checkout. May make script to choose this later

    public DialogueContainer nextConversation;
    public DialogueContainer[] conversations; //list of conversations that customer will progress through
    //may need to split up once conversation variants are added (happy/unhappy)

    public int conversationProgress = 0; //how far into conversations player is. Will want to save this variable somewhere


    // Start is called before the first frame update
    void Start()
    {
        nextConversation = conversations[conversationProgress]; //may need to put this on load somewhere
    }

   
    public void LoadNextConvo()
    {
        conversationProgress++;
        nextConversation = conversations[conversationProgress];
    }
}
