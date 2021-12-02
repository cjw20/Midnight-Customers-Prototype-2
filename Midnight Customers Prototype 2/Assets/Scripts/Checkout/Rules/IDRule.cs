using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDRule : Rule
{
    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;

        if(currentItem.requiresID && (currentItem.checkoutManager.needsIDCheck || currentItem.checkoutManager.failedIDCheck))
        {
            passed = false;
        }

        return passed;

    }
}
