using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public int phase; //which phase of rules this rule belongs to, starting with 0

    public bool passed; //true if rule was not broken
    CheckoutManager checkoutManager;
    private void Start()
    {
        checkoutManager = FindObjectOfType<CheckoutManager>();
    }

    public virtual bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;
        return passed;
    }

}
