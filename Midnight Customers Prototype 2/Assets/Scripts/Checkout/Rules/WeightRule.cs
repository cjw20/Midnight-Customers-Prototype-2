using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRule : Rule
{
    // Fields

    // References

    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;

        if(lastItem == null)
        {
            return true; //first item always passes
        }
        if(lastItem.weight < currentItem.weight)
        {
            passed = false;
            currentItem.checkoutManager.review.baggingErrors++;
            currentItem.checkoutManager.emoter.React("Angry");
        }
        return passed;
    }
}