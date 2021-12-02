using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRule : Rule
{
    public override bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;
        if(lastItem.weight < currentItem.weight)
        {
            passed = false;
        }
        return passed;
    }
}
