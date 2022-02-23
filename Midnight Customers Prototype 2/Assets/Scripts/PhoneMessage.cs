using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneMessage : MonoBehaviour
{
    // Fields
    [Header("Phone")]
    [Tooltip("Message to be displayed on the phone.")]
    public string message;

    // References
    [Header("UI References")]
    [Tooltip("Reference to the text object where message is displayed.")]
    public Text messageText;
    [Tooltip("Reference to the phone prefab.")]
    public GameObject OpenPhone;
    [Tooltip("Reference to the Sound Manager.")]
    [SerializeField] SoundManager soundManager;
   
    public void OpenMessage()
    {
        soundManager.PlayPhoneUnlockSound();
        OpenPhone.SetActive(true);

        messageText.text = message;

        this.gameObject.SetActive(false); //dismisses notification, keep if other uses for phone?
    }
}