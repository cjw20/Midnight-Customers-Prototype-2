using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    CustomerManager customerManager;

    NavMeshAgent2D agent;

    public Transform[] plannedPath; //an array of waypoints that the customer will travel to in course of time in store
    public Transform checkout;
    public Transform exit;

    public float minDistance = 0.5f;

    public int destination = 0;

    public float timeToWait = 5f; //time for customer to chill at destination before moving to next one
    bool isWaiting;


    public bool hasCheckedOut = false; //set to true after checkout minigame completed

    void Start()
    {
        
        //GoToNextPoint();
    }

    public void EnterStore()
    {
        customerManager = FindObjectOfType<CustomerManager>();
        agent = GetComponent<NavMeshAgent2D>();
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
            return;

        //is walking for footstep sounds

        if (!agent.pathPending && agent.remainingDistance < minDistance)
        {
            
            StartCoroutine(Wait());

        }


    }
    void GoToNextPoint()
    {
        if (destination >= plannedPath.Length)
        {
            //Destroy(this.gameObject); //customer leaves store when path is done
            return;
        }

        agent.destination = plannedPath[destination].position;

        destination++;

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
        GoToNextPoint();
    }

    public void ExitStore()
    {
        destination = 0; //resets customers planned path
        customerManager.CustomerExit(this.gameObject);
    }
}
