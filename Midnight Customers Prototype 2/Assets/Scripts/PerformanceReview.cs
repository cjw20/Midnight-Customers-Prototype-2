using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceReview : MonoBehaviour
{
    // Fields
    int lastPenalty;
    int thisScore; //score on how well player did, 3 = best, 0 worst
    int lastScore;
    [Header("Score Tracking")]
    [Tooltip("Total penalty points accumulated.")]
    public int totalPenaltyPoints;
    [Tooltip("Penalty points accumulated during the current day.")]
    public int dayPenaltyPoints;
    [Tooltip("The number of ID errors made.")]
    public int idErrors;
    [Tooltip("The number of bagging errors made.")]
    public int baggingErrors;

    [Header("Performance Messages")]
    [Tooltip("Message displayed when performance is good.")]
    public string goodMessage;
    [Tooltip("Message displayed when performance is bad.")]
    public string badMessage;
    [Tooltip("Message displayed when performance is average.")]
    public string neutralMessage;
    [Tooltip("Message displayed when performance has improved.")]
    public string improvedMessage;

    // References
    PhoneMessage phoneMessage;
    [Header("Object References")]
    [Tooltip("Reference to the phone notification prefab.")]
    public GameObject phoneNotification;
    [Tooltip("Reference to the Sound Manager.")]
    [SerializeField] SoundManager soundManager;

    public void NewMessage(string input = "") {
        soundManager.PlayTextMessageSound();
        phoneNotification.SetActive(true);
        if(phoneMessage == null)
        {
            phoneMessage = phoneNotification.GetComponent<PhoneMessage>();
        }

        phoneMessage.message = input;
    }

    
    void Start()
    {
        lastScore = 3; //first day expectations. Will need to load this when saving is implemented
    }

    public void NewDay()
    {
        totalPenaltyPoints += dayPenaltyPoints;
        lastPenalty = dayPenaltyPoints;
        dayPenaltyPoints = 0;
    }

    public void ReviewMessage()
    {
        soundManager.PlayTextMessageSound();
        phoneNotification.SetActive(true);
        if(phoneMessage == null)
        {
            phoneMessage = phoneNotification.GetComponent<PhoneMessage>();
        }
        phoneMessage.message = MessageSelect();
    }

    string MessageSelect()
    {
        string nextMessage;

        switch (lastPenalty)
        {
            case 0:
                nextMessage = goodMessage;
                thisScore = 3;
                break;
            case 1:
                nextMessage = neutralMessage;
                thisScore = 2;
                break;
            case 2:
                nextMessage = neutralMessage;
                thisScore = 2;
                break;
            default:
                nextMessage = badMessage;
                thisScore = 1;
                break;
        }
        if(thisScore > lastScore + 1)
        {
            nextMessage = improvedMessage; 
            //boss notes on improvement when player goes from bad to good
        }
        lastScore = thisScore;
        return nextMessage;
    }
}