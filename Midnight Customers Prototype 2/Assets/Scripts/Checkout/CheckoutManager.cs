using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutManager : MonoBehaviour
{
    // Fields
    int itemNumber; //number of items brought to checkout
    int remainingItems; //items left unbagged
    bool customerPayed;
    //bool passedIDCheck;
    bool finishedBag; //true when all items have been scanned
    int lastWeight = 3;
    float totalPrice;
    bool dialogueFinished; //set true by dialogue player when finished
    [Header("Checkout Information")]
    [Tooltip("Whether an ID check is needed or not.")]
    public bool needsIDCheck;
    [Tooltip("Whether the ID check was failed or not.")]
    public bool failedIDCheck;
    [Tooltip("Sum of errors in this checkout interaction.")]
    public int penaltyPoints; //sum of errors in this checkout
    [Tooltip("Current active phase.")]
    public int activePhase;

    // References
    CheckoutTrigger checkoutTrigger;
    GameObject[] items; //items brought to checkout
    List<GameObject> spawnedItems = new List<GameObject>();
    CustomerInfo customerInfo;
    List<Rule> activeRules = new List<Rule>();
    CheckoutItem currentItem;
    CheckoutItem lastItem;
    [Header("Misc References")]
    [Tooltip("Reference to a SoundManager class instance.")]
    [SerializeField] SoundManager soundManager;
    [Tooltip("Reference to a PerformanceReview class instance.")]
    public PerformanceReview review;
    [Tooltip("Reference to an EmoteController class instance.")]
    public EmoteController emoter;
    [Tooltip("Reference to a DialoguePlayer class instance.")]
    public DialoguePlayer dialoguePlayer;
    [Tooltip("Array of items to spawn.")]
    public GameObject[] itemSpawns;
    [Tooltip("Reference to a SpriteRenderer for the portrait location.")]
    public SpriteRenderer portraitLocation;
    [Tooltip("Array of Rules for phase 0 rules.")]
    [SerializeField] Rule[] phase0Rules;
    [Tooltip("Array of Rules for phase 1 rules.")]
    [SerializeField] Rule[] phase1Rules;
    [Tooltip("Reference to the Transform where money will be placed.")]
    public Transform moneySpawn; //where money gets placed
    [Header("UI References")]
    [Tooltip("Reference to the misbag message.")]
    public GameObject misbagMessage; //may replace in later versions
    [Tooltip("Reference to the ID button.")]
    public GameObject idButton; //probably don't need this reference later
    [Tooltip("Reference to the has ID message.")]
    public GameObject hasIDMessage;
    [Tooltip("Reference to the no ID message.")]
    public GameObject noIDMessage;
    [Tooltip("Reference to the Text object for price text.")]
    public Text priceText;
    [Tooltip("Reference to the Text object for weight text.")]
    public Text weightText;
    
    private void Start()
    {
        activePhase = 0; //load this variable when loading saved game
        checkoutTrigger = FindObjectOfType<CheckoutTrigger>();
        emoter = FindObjectOfType<EmoteController>();

        foreach(Rule rule in phase0Rules)
        {
            activeRules.Add(rule);
        }
    }

    public void LoadPhase1()
    {
        activePhase = 1;
        foreach(Rule rule in phase1Rules)
        {
            activeRules.Add(rule);
        }
    }

    public void StartCheckout(CustomerInfo info)
    {
        customerInfo = info;
        priceText.text = "$0.00";
        weightText.text = "-";
        needsIDCheck = false;
        //passedIDCheck = false;
        failedIDCheck = false;

        items = customerInfo.checkoutItems;
        portraitLocation.sprite = customerInfo.portrait;

        //pre convo messages before starting regular dialogue, like asking for something behind counter
        dialoguePlayer.StartConvo(customerInfo.nextConversation, customerInfo.dialogueFont);
        
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

    public void UpdateItem(CheckoutItem newItem)
    {
        lastItem = currentItem;
        currentItem = newItem;
    }

    public void Bagged(int weight, bool needsID)
    {
        foreach(Rule rule in activeRules)
        {            
            bool passed = rule.CheckRule(currentItem, lastItem);

            if (passed)
            {
                //add in increase to customer mood here?
            }
        }
        /*
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
        */
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

            currentItem = null;
            lastItem = null;
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
                //passedIDCheck = true;
            }
        }
    }
}