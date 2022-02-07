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
    [Tooltip("Rect Tranform for Minutes Hand on Time Window")]
    public RectTransform minutes_hand;
    [Tooltip("Rect Tranform for Hours Hand on Time Window")]
    public RectTransform hours_hand;
    [Tooltip("Black screen game object for fades during day transitions.")]
    public GameObject blackScreen; 
    [Tooltip("Reference to a Fade class instance.")]
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
    float minutes_last = 0f;

    // Start is called before the first frame update
    void Awake()
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
        UpdateClock();
    }

    public void OnLoadGame(int dayProgress)
    {
        day = dayProgress;
        NewDay();
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
            UpdateClock();
        }
    }

    void UpdateClock()
    {
        float elapsed = 0f; //accounts for time elapsed since last call
        elapsed = (minutes_last > minutes) ? 60 - minutes_last + minutes : minutes - minutes_last; 
        Vector3 min_rot = new Vector3(0f, 0f, elapsed * 6f);
        Vector3 h_rot = new Vector3(0f, 0f, elapsed * 0.5f);
        minutes_hand.Rotate(-min_rot);
        hours_hand.Rotate(-h_rot);
        minutes_last = minutes;
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

        GameControl.control.SaveGame("Day " + day.ToString()); //may not be best place to do this
        UpdateClock();
        toBlack.FadeOut(fadeDuration);
        NewDay();
        yield return new WaitForSeconds(fadeDuration + 2);
        blackScreen.SetActive(false);
        customerManager.StartSpawns();
        review.ReviewMessage();
        
        //check for story events for this night/next day and load them
        timerRunning = true;

        yield break;
    }



    void NewDay()
    {        
        taskSpawner.NewDayTasks();
        storyEvent.DayEvents(day); //loads any events for coming day

        if (day == 8)
        {
            checkoutManager.LoadPhase1();
        }
    }
}