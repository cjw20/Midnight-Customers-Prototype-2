using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float minutes;
    public float hours;
    public int day;
    public Text dayText;
    public Text timeText;

    bool singleDHour;
    bool singleDMin;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if(hours < 10)
        {
            singleDHour = true;
        }
        else
        {
            singleDHour = false;
        }

        if(minutes < 10)
        {
            singleDMin = true;
        }
        else
        {
            singleDMin = false;
        }
        UpdateText();
    }

    void UpdateText()
    {
        dayText.text = "Day: " + day.ToString();


        if (singleDHour)
        {
            timeText.text = "0" + hours.ToString();
        }
        else
        {
            timeText.text = "" + hours.ToString();
        }

        if (singleDMin)
        {
            timeText.text += ":0" + minutes.ToString();
        }
        else
        {
            timeText.text += ":" + minutes.ToString();
        }
    }
}
