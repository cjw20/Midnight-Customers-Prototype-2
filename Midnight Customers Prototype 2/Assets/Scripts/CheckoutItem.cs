using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutItem : MonoBehaviour
{
    public int price; //price of item to show up on register 
    public int itemName; //name of item
    //bool delicate? for if needs to be at top of bag
    //rules like alchoholic?
    public bool isScanned = false;

    public CheckoutManager checkoutManager;
    // Start is called before the first frame update
    void Start()
    {
        checkoutManager = FindObjectOfType<CheckoutManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bag"))
        {
            if (isScanned)
            {
                checkoutManager.UpdateCount();
                Destroy(this.gameObject);

            }
        }
        if (collision.CompareTag("Scanner"))
        {
            if (!isScanned)
            {
                isScanned = true;
                //mgControl.UpdatePrice(price);
                //scanSound.Play();
            }

        }
    }
}
