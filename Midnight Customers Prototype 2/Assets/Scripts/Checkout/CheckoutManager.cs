using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutManager : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public GameObject[] itemSpawns;
    GameObject[] items; //items brought to checkout

    List<GameObject> spawnedItems = new List<GameObject>();
    int itemNumber; //number of items brought to checkout
    int remainingItems; //items left unbagged

    bool finishedBag; //true when all items have been scanned
    public bool needsIDCheck;
    bool customerPayed;
    bool passedIDCheck;
    bool failedIDCheck;
    
    int lastWeight = 3;
    float totalPrice;

    bool dialogueFinished; //set true by dialogue player when finished
    public DialoguePlayer dialoguePlayer; 

    CheckoutTrigger checkoutTrigger;

    public GameObject misbagMessage; //may replace in later versions
    public GameObject idButton; //probably don't need this reference later
    public GameObject hasIDMessage;
    public GameObject noIDMessage;

    public SpriteRenderer portraitLocation;

    public Text priceText;
    public Text weightText;
    public Transform moneySpawn; //where money gets placed

    CustomerInfo customerInfo;

    int penaltyPoints; //sum of errors in this checkout
    public PerformanceReview review;

    public EmoteController emoter;

    private void Start()
    {
        checkoutTrigger = FindObjectOfType<CheckoutTrigger>();
        emoter = FindObjectOfType<EmoteController>();
    }
    public void StartCheckout(CustomerInfo info)
    {
        customerInfo = info;
        priceText.text = "$0.00";
        weightText.text = "-";
        needsIDCheck = false;
        passedIDCheck = false;
        failedIDCheck = false;

        items = customerInfo.checkoutItems;
        portraitLocation.sprite = customerInfo.portrait;

        //pre convo messages before starting regular dialogue, like asking for something behind counter
        dialoguePlayer.StartConvo(customerInfo.nextConversation);
        
        itemNumber = items.Length;
        remainingItems = itemNumber;

        int i = 0;
        foreach(GameObject item in items)
        {
            GameObject newItem = Instantiate(item, itemSpawns[i].transform);
            spawnedItems.Add(newItem);

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
    
    public void Bagged(int weight, bool needsID)
    {
        if(weight > lastWeight)
        {
            //StartCoroutine(DisplayMessage(misbagMessage, 1f)); //may need to do something that makes this not repeat if already going
            review.baggingErrors++;
            emoter.React("Angry");
        }
        lastWeight = weight;

        if (needsID && (needsIDCheck || failedIDCheck))
        {
            //happens when no valid id was checked and the item needed an ID
            penaltyPoints++;
            review.idErrors++;
            emoter.React("Happy");
        }
        remainingItems--;
        
        if(remainingItems < 1)
        {
            finishedBag = true;
            GiveMoney();
        }
        soundManager.PlayBaggingSound(weight);
    }

    void GiveMoney()
    {
        Instantiate(customerInfo.carriedMoney[0], moneySpawn);
    }
    public void TakeMoney()
    {
        soundManager.PlayCashRegisterSound();
        customerPayed = true;
        priceText.text = "PAID";
        EndCheckout();
    }
    public void ScanItem(float price, int weight)
    {
        totalPrice += price;
        priceText.text = "$" + totalPrice.ToString();
        DisplayWeight(weight);
        soundManager.PlayScannerSound();
    }

    public void PutAwayItem(bool scanned, float price, bool needsID)
    {
        soundManager.PlayDrawerSound();
        if (scanned)
        {
            //refund price
            totalPrice -= price;
            priceText.text = "$" + totalPrice.ToString();
        }
        if(failedIDCheck && needsID)
        {
            emoter.React("Sad"); 
            //customer sad that they cant buy item 
        }
        else
        {
            penaltyPoints++;
            review.idErrors++;
            emoter.React("Angry");
            //customer mad that they werent allowed to buy item they should have
        }
        remainingItems--;

        if(remainingItems < 1)
        {
            //checks if all items are bagged or put away
            finishedBag = true;
            GiveMoney();
        }
    }

    void EndCheckout()
    {
        if (finishedBag && dialogueFinished && customerPayed) 
        {
            checkoutTrigger.EndCheckout();
            checkoutTrigger.customerInfo.GetComponent<CustomerMovement>().FinishedCheckout();
            
            dialogueFinished = false;
            customerPayed = false;
            
            lastWeight = 3; //resets for next bagging
            totalPrice = 0;
            
            if (needsIDCheck)
            {
                penaltyPoints++;
                //forgot to check id
            }
            review.dayPenaltyPoints += penaltyPoints; //sends penalty points to performance review and recents
            penaltyPoints = 0;

            needsIDCheck = false;
            //will need to clear other stuff for future checkouts OR reinstantiate whole object?
            this.gameObject.SetActive(false);
        }

    }


    public void GiveUp()
    {

        //for when customer leaves early

        checkoutTrigger.EndCheckout();
        checkoutTrigger.customerInfo.GetComponent<CustomerMovement>().FinishedCheckout();

        dialogueFinished = false;
        customerPayed = false;

        lastWeight = 3; //resets for next bagging
        totalPrice = 0;

        if (needsIDCheck)
        {
            penaltyPoints++;
            //forgot to check id
        }
        review.dayPenaltyPoints += penaltyPoints; //sends penalty points to performance review and recents
        penaltyPoints = 0;

        needsIDCheck = false;
        
        foreach(GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear();
        //will need to reset dialogue and items!

        this.gameObject.SetActive(false);
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
            int idRoll = Random.Range(0, 100);
            if (idRoll < 25)
            {
                StartCoroutine(DisplayMessage(noIDMessage, 2f));
                needsIDCheck = false;
                failedIDCheck = true;
            }
            else
            {
                StartCoroutine(DisplayMessage(hasIDMessage, 2f));
                needsIDCheck = false;
                passedIDCheck = true;
            }
        }
        
    }
}
