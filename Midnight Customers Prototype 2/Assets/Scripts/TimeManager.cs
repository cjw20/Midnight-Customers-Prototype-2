using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Fields
    [Header("Time Controls")]
    [Tooltip("Current day.")]
    public int day;
    [Tooltip("Current hour of the current day.")]
    public float hours;
    [Tooltip("Current minutes of the current hour.")]
    public float minutes;
    [Tooltip("Current seconds of the current minute.")]
    public float seconds;
    [Tooltip("How much faster than real time in game time passes.")]
    public float timeMultiplier;
    [Tooltip("Duration of fade from one day to the next.")]
    public float fadeDuration;
    private bool timerRunning;

    // References
    [Header("UI Object References")]
    [Tooltip("Text to display the current day.")]
    public Text dayText;
    [Tooltip("Text to display the current time of the current day.")]
    public Text timeText;
    [Tooltip("Black screen game object for fades during day transitions.")]
    public GameObject blackScreen; 
    [Tooltip("Reference to the Fade class.")]
    public Fade toBlack;

    [Header("Player References")]
    [Tooltip("Player start location.")]
    public Transform playerStartingLoc;

    GameObject player;
    PlayerMovement playerMovement;
    CustomerManager customerManager;
    TaskSpawner taskSpawner;
    PerformanceReview review;
    StoryEventHandler storyEvent;
    RandomEventManager randomEvent;
    CheckoutManager checkoutManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        customerManager = FindObjectOfType<CustomerManager>();
        taskSpawner = FindObjectOfType<TaskSpawner>();
        review = FindObjectOfType<PerformanceReview>();
        storyEvent = FindObjectOfType<StoryEventHandler>();
        randomEvent = FindObjectOfType<RandomEventManager>();
        checkoutManager = FindObjectOfType<CheckoutManager>();
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
                if(hours < 5)
                {
                    randomEvent.CallRandomEvent();
                }
                minutes = 0;
            }

            if(hours == 4 && minutes == 30)
            {
                customerManager.PauseSpawns();
                //lazy way to make it so there wont be customers in store when it starts to close
            }

            if (hours >= 6)
            {
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
        blackScreen.SetActive(true);
        toBlack.FadeIn(fadeDuration);
        taskSpawner.ClearTasks(); //get penalties from unfinished tasks
        review.dayPenaltyPoints += taskSpawner.unfinishedTasks;
        review.NewDay(); //tallys up penalties
        //move player, stop customer spawns etc. new tasks
        yield return new WaitForSeconds(fadeDuration + 2);
        customerManager.StopSpawns();
        player.transform.position = playerStartingLoc.position;
        hours = 0;
        day++;
        if(day == 8)
        {
            checkoutManager.LoadPhase1();
        }
        UpdateText();
        toBlack.FadeOut(fadeDuration);
        taskSpawner.NewDayTasks();
        
        storyEvent.DayEvents(day); //loads any events for coming day
        yield return new WaitForSeconds(fadeDuration + 2);
        blackScreen.SetActive(false);
        customerManager.StartSpawns();

        review.ReviewMessage();
        
        //check for story events for this night/next day and load them
        timerRunning = true;

        yield break;
    }
}