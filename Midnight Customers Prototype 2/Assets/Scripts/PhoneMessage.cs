using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneMessage : MonoBehaviour
{
    public string message;
    public Text messageText;
    public GameObject OpenPhone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMessage()
    {
        OpenPhone.SetActive(true);

        messageText.text = message;
    }
}