using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceReview : MonoBehaviour
{
    public int totalPenaltyPoints;
    public int dayPenaltyPoints;
    int lastPenalty;
    public int idErrors;
    public int baggingErrors;

    public GameObject phoneNotification;
    PhoneMessage phoneMessage;

    public string goodMessage;
    public string badMessage;
    public string neutralMessage;
    public string improvedMessage;
    int thisScore; //score on how well player did, 3 = best, 0 worst
    int lastScore;

    // Start is called before the first frame update
    void Start()
    {
        lastScore = 3; //first day expectations. Will need to load this when saving is implemented
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDay()
    {
        totalPenaltyPoints += dayPenaltyPoints;
        lastPenalty = dayPenaltyPoints;
        dayPenaltyPoints = 0;
    }

    public void ReviewMessage()
    {
        phoneNotification.SetActive(true);
        if(phoneMessage == null)
        {
            phoneMessage = phoneNotification.GetComponent<PhoneMessage>();

        }

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
        return nextMessage;
    }
}
