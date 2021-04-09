using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager customerManager;

    [SerializeField] GameObject human1;
    [SerializeField] GameObject human2;
    [SerializeField] GameObject aylith;
    public GameObject[] customers;
    [SerializeField] Transform exit;

    int arrayPos;
    Coroutine lastCoroutine;

    List<GameObject> customersInStore = new List<GameObject>();
    
    void Awake()
    {
        if (customerManager == null)
        {
            DontDestroyOnLoad(gameObject);  //makes sure there is only one game control in scene. 
            customerManager = this;
        }
        else if (customerManager != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        arrayPos = Random.Range(0, customers.Length); //dont need +1 if inclusive?

        LoadCustomer(customers[arrayPos]);
    }

    

    public void LoadCustomer(GameObject customer)
    {
        CustomerMovement move = customer.GetComponent<CustomerMovement>();
        customer.SetActive(true);
        customersInStore.Add(customer);
        move.EnterStore();
        customer.transform.position = exit.position;
        //play sound for customer entering store
        //Set path
        //update any variables in customer info

        arrayPos++;
        if(arrayPos >= customers.Length)
        {
            arrayPos = 0;
        }
    }

    public void CustomerExit(GameObject customer)
    {
        //customersInStore.Remove(customer);
        customer.SetActive(false);

        lastCoroutine = StartCoroutine(NextCustomer());
        //update customer variables
    }

    IEnumerator NextCustomer()
    {
        yield return new WaitForSeconds(5);
        LoadCustomer(customers[arrayPos]); //logic for this later when more customers to choose from
        lastCoroutine = null;
        yield break;
    }

    public void PauseSpawns()
    {
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
        lastCoroutine = StartCoroutine(NextCustomer());
    }


}
