using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutManager : MonoBehaviour
{
    public GameObject[] itemSpawns;
    public GameObject[] items; //items brought to checkout
    int itemNumber; //number of items brought to checkout
    int remainingItems; //items left unbagged

    bool finishedBag; //true when all items have been scanned
    bool needsIDCheck;
    bool checkedID;
    int lastWeight = 3;
    float totalPrice;

    CheckoutTrigger checkoutTrigger;

    public GameObject misbagMessage; //may replace in later versions
    public GameObject idButton; //probably don't need this reference later

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

    
    public void Bagged(int weight, float price)
    {
        if(weight > lastWeight)
        {
            StartCoroutine(Miss()); //may need to do something that makes this not repeat if already going
            
        }
        lastWeight = weight;

        remainingItems--;
        totalPrice += price;
        if(remainingItems < 1)
        {
            finishedBag = true;
            EndCheckout();
        }
    }

    void EndCheckout()
    {
        if (finishedBag) //add finished convo too later once implemented
        {
            checkoutTrigger.inCheckout = false;
            this.gameObject.SetActive(false);
            lastWeight = 3; //resets for next bagging
            totalPrice = 0;
            needsIDCheck = false;
            //will need to clear other stuff for future checkouts OR reinstantiate whole object?
        }

    }

    IEnumerator Miss()
    {
        misbagMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        misbagMessage.SetActive(false);
        yield break;
    }

    public void CheckID()
    {
        needsIDCheck = false;
    }
}
