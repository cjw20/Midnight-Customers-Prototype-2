using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutItem : MonoBehaviour
{
    public float price; //price of item to show up on register 
    public string itemName; //name of item
    public int weight; //1 light 2 medium 3 heavy
    public bool requiresID;
    //bool delicate? for if needs to be at top of bag
    //rules like alchoholic?
    public bool isScanned = false;

    bool breaksRules;

    

    public CheckoutManager checkoutManager;
    // Start is called before the first frame update
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

        if (collision.CompareTag("Drawer"))
        {
            checkoutManager.PutAwayItem(isScanned, price, requiresID);
            Destroy(this.gameObject);
        }
    }
}
