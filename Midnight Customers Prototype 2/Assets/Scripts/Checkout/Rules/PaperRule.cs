using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperRule : Rule
{
    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;

        if(lastItem == null)
        {
            return true; //first item always passes
        }

        if(currentItem.foodItem && lastItem.paperItem)
        {
            passed = false;
            currentItem.checkoutManager.review.baggingErrors++;
            currentItem.checkoutManager.emoter.React("Angry");
        }
        return passed;
    }
}
