using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutItem : MonoBehaviour
{
    // Fields
    [Header("Checkout Item Data")]
    [Tooltip("Price of item that shows up on the register.")]
    public float price; //price of item to show up on register
    [Tooltip("The name of the item.")]
    public string itemName; //name of item
    [Tooltip("The weight of the item. 1 = Light, 2 = Medium, 3 = Heavy.")]
    public int weight; //1 light 2 medium 3 heavy
    [Tooltip("Whether the item requires an ID or not.")]
    public bool requiresID;
    //bool delicate? for if needs to be at top of bag
    //rules like alchoholic?
    [Tooltip("Whether the item has been scanned or not.")]
    public bool isScanned = false;
    [Tooltip("Whether the item is food or not.")]
    public bool foodItem; //true if food
    [Tooltip("Whether the item is made of paper or not. (Make sure weight is 1 if true).")]
    public bool paperItem; //make sure weight is 1 for these items

    // References
    [Header("References")]
    [Tooltip("Reference to a CheckoutManager class instance.")]
    public CheckoutManager checkoutManager;

    void Start()
    {
        checkoutManager = FindObjectOfType<CheckoutManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bag"))
        {
            if (isScanned)
            {
                checkoutManager.UpdateItem(this);
                checkoutManager.Bagged(weight, requiresID);

                Destroy(this.gameObject);
                //penalty for bagging w/out scan? or make customer happy?
            }
        }
        if (collision.CompareTag("Scanner"))
        {
            if (!isScanned)
            {
                isScanned = true;
                checkoutManager.ScanItem(price, weight);
            }

        }

        /*if (collision.CompareTag("Drawer")) Moved to OnTriggerStay2D
        {
            checkoutManager.PutAwayItem(isScanned, price, requiresID);
            Destroy(this.gameObject);
        }
        */
    }

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.CompareTag("Drawer") && !Input.GetMouseButton(0)) {
            checkoutManager.PutAwayItem(isScanned, price, requiresID);
            Destroy(this.gameObject);
        }
    }
}