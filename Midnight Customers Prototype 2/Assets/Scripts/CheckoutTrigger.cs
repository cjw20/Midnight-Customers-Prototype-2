using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    public bool playerReady; //true when player is standing behind register
    public bool customerReady; //true when customer is standing in front of register, ready to check out
    public GameObject checkoutGame;

    public GameObject customer; //customer standing in front of checkout
    public CustomerInfo customerInfo;

    public bool inCheckout; //true while checkout game going on
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerReady && customerReady && !inCheckout)//and customer ready too later once implemented
            {
                inCheckout = true;
                checkoutGame.SetActive(true);
                //do rest of checkout trigger ehre
            }
        } 
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = true;
        }

        if (collision.CompareTag("Customer"))
        {
            customerReady = true;
            customer = collision.gameObject;
            customerInfo = customer.GetComponent<CustomerInfo>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = false;
        }

        if (collision.CompareTag("Customer"))
        {
            customerReady = false;
            customer = null;
            customerInfo = null; //clears out customer data 
        }
    }
}
