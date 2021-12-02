using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperRule : Rule
{
    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;

        if(currentItem.foodItem && lastItem.paperItem)
        {
            passed = false;
        }
        return passed;
    }
}
