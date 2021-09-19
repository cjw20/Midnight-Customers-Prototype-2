using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float value;
    CheckoutManager checkoutManager;

    //animation or movement towards counter 
    private void Start()
    {
        checkoutManager = GameObject.FindObjectOfType<CheckoutManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CashReg"))
        {
            checkoutManager.TakeMoney();
            Destroy(this.gameObject);
        }
        
    }
}