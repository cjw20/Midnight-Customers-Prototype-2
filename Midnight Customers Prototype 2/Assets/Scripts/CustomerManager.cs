using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager customerManager;

    [SerializeField] GameObject human1;
    [SerializeField] CustomerInfo human1Info; //may not need this reference?

    [SerializeField] Transform exit;
    
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
        LoadCustomer(human1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCustomer(GameObject customer)
    {
        customer.SetActive(true);
        customer.transform.position = exit.position;
        //play sound for customer entering store
        //Set path
        //update any variables in customer info
    }

    public void CustomerExit(GameObject customer)
    {
        customer.SetActive(false);
        //update variables
    }


}
