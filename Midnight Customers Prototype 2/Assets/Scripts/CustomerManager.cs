using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Fields
    bool spawning;
    public int arrayPos;

    // References
    Coroutine lastCoroutine;
    [Header("Customer Management")]
    [Tooltip("Reference to a CustomerMangager class instance.")]
    public static CustomerManager customerManager;
    [Tooltip("List of customers.")]
    public GameObject[] customers;
    [Tooltip("Point of exit for the customers.")]
    [SerializeField] Transform exit;
    [Tooltip("List of the customers currently in the store.")]
    List<GameObject> customersInStore = new List<GameObject>();

    void Awake()
    {
        if(GameControl.control.loadingGame == false)
        {
            OnLoadGame(0); //call this from game control later, only here to keep game from breaking while loading is implemented
        }
        
    }

    public void OnLoadGame(int progress)
    {
        arrayPos = progress;
        spawning = true;
        LoadCustomer(customers[arrayPos]);
    }
    public void LoadCustomer(GameObject customer)
    {
        CustomerMovement move = customer.GetComponent<CustomerMovement>();
        customer.SetActive(true);
        customersInStore.Add(customer);
        move.EnterStore();
        customer.transform.position = exit.position;
        customer.GetComponentInChildren<MoodIndicator>().SetMood("happy");
        //play sound for customer entering store
        //Set path
        //update any variables in customer info

        arrayPos++;
        if(arrayPos >= customers.Length)
        {
            spawning = false; //so spawning stops happening only for gdex build
           // arrayPos = 0;
        }
    }

    public void CustomerExit(GameObject customer)
    {
        //customersInStore.Remove(customer); will need to find work around if we ever decide to have multiple customers in the store at once
        customer.SetActive(false);

        if (spawning)
        {
            lastCoroutine = StartCoroutine(NextCustomer());
            //update customer variables
        }
    }

    IEnumerator NextCustomer()
    {
        yield return new WaitForSeconds(8);
        LoadCustomer(customers[arrayPos]); //logic for this later when more customers to choose from
        lastCoroutine = null;
        yield break;
    }

    public void StopSpawns()
    {
        spawning = false;
        if(lastCoroutine != null)
        {
            
            StopCoroutine(lastCoroutine);
            lastCoroutine = null;
        }
        foreach (GameObject customer in customersInStore)
        {
            customer.transform.position = exit.position;
            customer.GetComponent<CustomerMovement>().ExitStore();
        }
        customersInStore.Clear();
    }

    public void StartSpawns()
    {
        spawning = true;
        lastCoroutine = StartCoroutine(NextCustomer());
    }

    public void PauseSpawns()
    {
        spawning = false;
    }
}