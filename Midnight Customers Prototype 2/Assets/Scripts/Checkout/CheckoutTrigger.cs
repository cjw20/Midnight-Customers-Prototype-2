using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    // Fields
    [Header("Checkout Data")]
    [Tooltip("Whether the player is standing behind the register or not.")]
    public bool playerReady; //true when player is standing behind register
    [Tooltip("Whether the customer is in front of the register and ready to checkout or not.")]
    public bool customerReady; //true when customer is standing in front of register, ready to check out
    [Tooltip("Whether the checkout minigame is running or not.")]
    public bool inCheckout; //true while checkout game going on

    // References
    PlayerMovement playerMove;
    private PlayerInput playerInput; //asset that has player controls
    CheckoutManager checkoutManager;
    [Header("References")]
    [Tooltip("Reference to a CheckoutTimer class instance.")]
    [SerializeField] CheckoutTimer checkoutTimer;
    [Tooltip("Reference to the checkout game prefab.")]
    public GameObject checkoutGame;
    [Tooltip("Reference to the customer that is ready to checkout.")]
    public GameObject customer; //customer standing in front of checkout
    [Tooltip("Reference to a CustomerInfo class instance.")]
    public CustomerInfo customerInfo;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Start()
    {
        checkoutManager = checkoutGame.GetComponent<CheckoutManager>(); //may not need this part later
    }

    void Update()
    {
        /*
        if (playerInput.Store.Interact.triggered)
        {
            if (playerReady && customerReady && !inCheckout)//and customer ready too later once implemented
            {
                playerMove.moveable = false;
                inCheckout = true;
                checkoutGame.SetActive(true);
                checkoutManager.StartCheckout(customerInfo);
                checkoutTimer.inCheckout = true; //starts updating timer
                checkoutTimer.UpdateValue(-checkoutTimer.timePassed); //has ui reflect time customer spent waiting before player showed up
            }
            
        // old input method
        */
    }

    public void TriggerCheckout()
    {
        if (playerReady && customerReady && !inCheckout)//and customer ready too later once implemented
        {
            playerMove.moveable = false;
            inCheckout = true;
            checkoutGame.SetActive(true);
            checkoutManager.StartCheckout(customerInfo);
            checkoutTimer.inCheckout = true; //starts updating timer
            checkoutTimer.UpdateValue(-checkoutTimer.timePassed); //has ui reflect time customer spent waiting before player showed up
        }
    }

    public void EndCheckout()
    {
        playerMove.moveable = true;
        playerMove.Epopup.SetActive(false);
        inCheckout = false;
        checkoutTimer.ResetTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = true;
            playerMove = collision.gameObject.GetComponent<PlayerMovement>();
            if(customerReady) playerMove.Epopup.SetActive(true); //Only pops up if waiting on Customer
            playerMove.checkoutTrigger = this;
        }

        if (collision.CompareTag("Customer"))
        {
            if (collision.gameObject.GetComponent<CustomerMovement>().readyForCheckout)
            {
                customerReady = true;
                customer = collision.gameObject;
                customerInfo = customer.GetComponent<CustomerInfo>();
                if (playerReady) playerMove.Epopup.SetActive(true); //Only pops up if waiting on Customer
                checkoutTimer.StartTimer(customerInfo); //starts global timer for checkout
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = false;
            playerMove.Epopup.SetActive(false);
            playerMove.checkoutTrigger = null;
        }

        if (collision.CompareTag("Customer"))
        {
             customerReady = false;
             customer = null;
             customerInfo = null; //clears out customer data
        }
    }
}