using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    public bool playerReady; //true when player is standing behind register
    public bool customerReady; //true when customer is standing in front of register, ready to check out
    public GameObject checkoutGame;
    CheckoutManager checkoutManager;

    public GameObject customer; //customer standing in front of checkout
    public CustomerInfo customerInfo;
    PlayerMovement playerMove;

    public bool inCheckout; //true while checkout game going on
    void Start()
    {
        checkoutManager = checkoutGame.GetComponent<CheckoutManager>(); //may not need this part later
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            if (playerReady && customerReady && !inCheckout)//and customer ready too later once implemented
            {
                playerMove.moveable = false;
                inCheckout = true;
                checkoutGame.SetActive(true);
                checkoutManager.StartCheckout(customerInfo);
                //do rest of checkout trigger ehre
            }
        } 
    }

    public void EndCheckout()
    {
        playerMove.moveable = true;
        inCheckout = false;

    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = true;
            playerMove = collision.gameObject.GetComponent<PlayerMovement>();
            playerMove.Epopup.SetActive(true);
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
            playerMove.Epopup.SetActive(false);
        }

        if (collision.CompareTag("Customer"))
        {
            customerReady = false;
            customer = null;
            customerInfo = null; //clears out customer data 
        }
    }
}
