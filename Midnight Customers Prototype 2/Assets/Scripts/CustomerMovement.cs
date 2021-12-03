using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    CustomerManager customerManager;
    SoundManager soundManager;

    NavMeshAgent2D agent;

    public Transform[] plannedPath; //an array of waypoints that the customer will travel to in course of time in store
    public Transform checkout;
    public Transform exit;

    public float minDistance = 0.5f;

    public int destination = 0;

    public float timeToWait = 5f; //time for customer to chill at destination before moving to next one
    bool isWaiting;

    Vector2 velocity;

    public bool hasCheckedOut = false; //set to true after checkout minigame completed
    public bool readyForCheckout; //so checkout wont be available if customer walks past counter before ready

    Vector3 lastPosition;
    float speed;

    [SerializeField] Animator animator;

    private void Awake()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    void Start()
    {
        //GoToNextPoint();
    }

    public void EnterStore()
    {
        soundManager.PlayDoorbellSound();
        customerManager = FindObjectOfType<CustomerManager>();
        agent = GetComponent<NavMeshAgent2D>();
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = agent.velocity; //for animator stuff
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        if (velocity.magnitude <= 0.1f) {
            animator.SetBool("Moving",false);
        } else {
            animator.SetBool("Moving",true);
        }
        if (isWaiting)
            return;

        //is walking for footstep sounds

        if (!agent.pathPending && agent.remainingDistance < minDistance)
        {
            
            StartCoroutine(Wait());

        }
    }
    // //https://gamedev.stackexchange.com/questions/133380/how-do-i-find-an-accurate-current-speed-of-a-navmesh-agent
    // void FixedUpdate()
    // {
    //     speed = Mathf.Lerp(speed, (transform.position - lastPosition).magnitude, 0.7f /*adjust this number in order to make interpolation quicker or slower*/);
    //     lastPosition = transform.position;
    //     animator.SetFloat("Horizontal", speed);
    //     animator.SetFloat("Vertical", speed);
        
    // }
    void GoToNextPoint()
    {
        if (destination >= plannedPath.Length)
        {
            //Destroy(this.gameObject); //customer leaves store when path is done
            return;
        }

        agent.destination = plannedPath[destination].position;

        destination++;
        if (agent.destination == new Vector2(checkout.position.x, checkout.position.y))
        {
            readyForCheckout = true;
        }

        isWaiting = false;
    }

    IEnumerator Wait()
    {

        isWaiting = true;

        if (agent.destination == new Vector2(exit.position.x, exit.position.y))
        {
            ExitStore();

            yield break;
            //save properties like convo progress, get ready for next load 
        }

        if (agent.destination == new Vector2(checkout.position.x, checkout.position.y))
        {
            readyForCheckout = true;
            yield break; //make function that calls next point after checkout done
            //wait until checkout minigame done
        }


        yield return new WaitForSeconds(timeToWait);

        GoToNextPoint();
        yield break;
    }

    public void FinishedCheckout()
    {
        //call from MG script after completion
        isWaiting = false;
        hasCheckedOut = true;
        readyForCheckout = false;
        GoToNextPoint();
    }

    public void ExitStore()
    {
        destination = 0; //resets customers planned path
        customerManager.CustomerExit(this.gameObject);
        soundManager.PlayDoorbellSound();
    }
}
