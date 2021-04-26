using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float minutes;
    public float hours;
    public float seconds;
    public int day;
    public Text dayText;
    public Text timeText;
    public float timeMultiplier; //how much faster than real time in game time passes

    bool timerRunning;

    public Fade toBlack;
    public float fadeDuration;

    GameObject player;
    PlayerMovement playerMovement;
    public Transform playerStartingLoc;

    CustomerManager customerManager;
    TaskSpawner taskSpawner;
    PerformanceReview review;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        customerManager = FindObjectOfType<CustomerManager>();
        taskSpawner = FindObjectOfType<TaskSpawner>();
        review = FindObjectOfType<PerformanceReview>();
        //if ^ is too slow, do different way later
        timerRunning = true;
        UpdateText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerRunning)
        {
            seconds += Time.fixedDeltaTime * timeMultiplier;
            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }
            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
            }

            if (hours >= 6)
            {
                hours = 0;
                day++;
                timerRunning = false;
                StartCoroutine(EndDay());
            }
            UpdateText();
        }
        
    }

    void UpdateText()
    {
        dayText.text = "Day: " + day.ToString();


        if (hours < 10)
        {
            timeText.text = "0" + hours.ToString();
        }
        else
        {
            timeText.text = "" + hours.ToString();
        }

        if (minutes < 10)
        {
            timeText.text += ":0" + minutes.ToString();
        }
        else
        {
            timeText.text += ":" + minutes.ToString();
        }
    }

    IEnumerator EndDay()
    {
        while (!playerMovement.moveable)
        {
            //waits till checkout or minigame is done
            yield return new WaitForEndOfFrame();
        }
        //check if in checkout or task. wait till finished
        toBlack.FadeIn(fadeDuration);
        review.NewDay(); //tallys up penalties
        //move player, stop customer spawns etc. new tasks
        yield return new WaitForSeconds(fadeDuration + 2);
        customerManager.StopSpawns();
        player.transform.position = playerStartingLoc.position;
        toBlack.FadeOut(fadeDuration);
        taskSpawner.NewDayTasks();
        yield return new WaitForSeconds(fadeDuration + 2);
        customerManager.StartSpawns();

        review.ReviewMessage();
        
        //check for story events for this night/next day and load them
        timerRunning = true;

        yield break;
    }
}
