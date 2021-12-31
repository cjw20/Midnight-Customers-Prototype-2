using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    // Fields
    [Header("Rule Data")]
    [Tooltip("Which phase of rules this rule belongs to, starting with 0.")]
    public int phase;
    [Tooltip("Whether the rule was broken or not. (True if rule was NOT broken)")]
    public bool passed;

    // References

    public virtual bool CheckRule(CheckoutItem currentItem, CheckoutItem lastItem)
    {
        passed = true;
        return passed;
    }
}