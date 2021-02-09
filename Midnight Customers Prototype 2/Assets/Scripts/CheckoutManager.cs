using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutManager : MonoBehaviour
{
    public GameObject[] itemSpawns;
    public GameObject[] items; //items brought to checkout
    int itemNumber; //number of items brought to checkout
    int remainingItems; //items left unbagged

    bool finishedScan; //true when all items have been scanned

    CheckoutTrigger checkoutTrigger;
    // Start is called before the first frame update

    private void Start()
    {
        checkoutTrigger = FindObjectOfType<CheckoutTrigger>();
    }
    void OnEnable()
    {
        

        //get items from customer
        itemNumber = items.Length;
        remainingItems = itemNumber;

        int i = 0;
        foreach(GameObject item in items)
        {
            Instantiate(item, itemSpawns[i].transform);
            i++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount()
    {
        remainingItems--;
        if(remainingItems < 1)
        {
            finishedScan = true;
            EndCheckout();
        }
    }

    void EndCheckout()
    {
        if (finishedScan) //add finished convo too later once implemented
        {
            checkoutTrigger.inCheckout = false;
            this.gameObject.SetActive(false);
            //will need to clear other stuff for future checkouts OR reinstantiate whole object?
        }

    }
}
