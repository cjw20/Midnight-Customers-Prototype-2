using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDRule : Rule
{
    // Fields

    // References

    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;

        if(currentItem.requiresID && (currentItem.checkoutManager.needsIDCheck || currentItem.checkoutManager.failedIDCheck))
        {
            passed = false;
            currentItem.checkoutManager.penaltyPoints++;
            currentItem.checkoutManager.review.idErrors++;
            currentItem.checkoutManager.emoter.React("Happy");
        }

        return passed;
    }
}