using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneMessage : MonoBehaviour
{
    public string message;
    public Text messageText;
    public GameObject OpenPhone;
   
    public void OpenMessage()
    {
        OpenPhone.SetActive(true);

        messageText.text = message;

        this.gameObject.SetActive(false); //dismisses notifcation, keep if other uses for phone?
    }
}
