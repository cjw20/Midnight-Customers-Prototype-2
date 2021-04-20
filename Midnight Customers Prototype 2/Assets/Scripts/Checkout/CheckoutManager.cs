using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutManager : MonoBehaviour
{
    public GameObject[] itemSpawns;
    GameObject[] items; //items brought to checkout
    int itemNumber; //number of items brought to checkout
    int remainingItems; //items left unbagged

    bool finishedBag; //true when all items have been scanned
    public bool needsIDCheck;
    bool customerPayed;
    
    int lastWeight = 3;
    float totalPrice;

    bool dialogueFinished; //set true by dialogue player when finished
    public DialoguePlayer dialoguePlayer; 

    CheckoutTrigger checkoutTrigger;

    public GameObject misbagMessage; //may replace in later versions
    public GameObject idButton; //probably don't need this reference later
    public GameObject idMessage;

    public SpriteRenderer portraitLocation;

    public Text priceText;
    public Text weightText;
    public Transform moneySpawn; //where money gets placed

    CustomerInfo customerInfo;

    public AudioSource scanSound;

    private void Start()
    {
        checkoutTrigger = FindObjectOfType<CheckoutTrigger>();

    }
    public void StartCheckout(CustomerInfo info)
    {
        customerInfo = info;
        priceText.text = "$0.00";
        weightText.text = "-";

        items = customerInfo.checkoutItems;
        portraitLocation.sprite = customerInfo.portrait;

        dialoguePlayer.StartConvo(customerInfo.nextConversation);
        
        itemNumber = items.Length;
        remainingItems = itemNumber;

        int i = 0;
        foreach(GameObject item in items)
        {
            Instantiate(item, itemSpawns[i].transform);

            if(needsIDCheck == false) //skips over to be more efficent
            {
                if (item.GetComponent<CheckoutItem>().requiresID == true)
                {
                    needsIDCheck = true;
                }
            }
           
            i++;
        }

        
    }

    public void EndDialogue(int relationshipChange)
    {
        customerInfo.UpdateRelationship(relationshipChange);
        customerInfo.LoadNextConvo();
        dialogueFinished = true;
        EndCheckout();
    }
    
    public void Bagged(int weight)
    {
        if(weight > lastWeight)
        {
            StartCoroutine(DisplayMessage(misbagMessage, 1f)); //may need to do something that makes this not repeat if already going
            
        }
        lastWeight = weight;

        remainingItems--;
        
        if(remainingItems < 1)
        {
            finishedBag = true;
            GiveMoney();
        }
    }

    void GiveMoney()
    {
        Instantiate(customerInfo.carriedMoney[0], moneySpawn);
    }
    public void TakeMoney()
    {
        customerPayed = true;
        priceText.text = "PAID";
        EndCheckout();
    }
    public void ScanItem(float price, int weight)
    {
        totalPrice += price;
        priceText.text = "$" + totalPrice.ToString();
        DisplayWeight(weight);
        scanSound.Play();
    }

    void EndCheckout()
    {
        if (finishedBag && dialogueFinished && customerPayed) //add finished convo too later once implemented
        {
            checkoutTrigger.EndCheckout();
            checkoutTrigger.customerInfo.GetComponent<CustomerMovement>().FinishedCheckout();
            
            dialogueFinished = false;
            customerPayed = false;
            
            lastWeight = 3; //resets for next bagging
            totalPrice = 0;
            
            if (needsIDCheck)
            {
                //bad! deduct points or something
            }
            needsIDCheck = false;
            //will need to clear other stuff for future checkouts OR reinstantiate whole object?
            this.gameObject.SetActive(false);
        }

    }

    void DisplayWeight(int weight)
    {
        var weightCharacter = weight switch
        {
            1 => "L",
            2 => "M",
            3 => "H",
            _ => "?",
        }; //defaults to ? in case of error or if we want to mess with player
        weightText.text = weightCharacter;
    }

    IEnumerator Miss()
    {
        misbagMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        misbagMessage.SetActive(false);
        yield break;
        //unused
    }
    

    IEnumerator DisplayMessage(GameObject message, float duration)
    {
        message.SetActive(true);
        yield return new WaitForSeconds(duration);
        message.SetActive(false);
        yield break;
    }

    public void CheckID()
    {
        if (needsIDCheck)
        {
            StartCoroutine(DisplayMessage(idMessage, 2f));
            needsIDCheck = false;
        }
        
    }
}
