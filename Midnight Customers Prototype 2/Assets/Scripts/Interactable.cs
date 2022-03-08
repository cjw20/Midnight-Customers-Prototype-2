using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    // Fields
    bool inRange;
    bool interacting;
    [Header("Data")]
    [Tooltip("Various messages.")]
    [SerializeField] string[] messages;
    [Tooltip("Progress.")]
    public int progress;

    // References
    private PlayerInput playerInput; //asset that has player controls
    [Header("UI References")]
    [Tooltip("Reference to the thought text object.")]
    [SerializeField] GameObject thoughtText;
    [Tooltip("Reference to the thought window object.")]
    [SerializeField] GameObject thoughtWindow;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void SetMessage(string[] input){
        messages = input;
    }

    public void TriggerInteractable()
    {
        if (inRange && !interacting)
        {
            interacting = true;
            StartCoroutine(DisplayMessage(messages[progress]));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            collision.gameObject.GetComponent<PlayerMovement>().Qpopup.SetActive(true);
            collision.gameObject.GetComponent<PlayerMovement>().nearbyInteractable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            collision.gameObject.GetComponent<PlayerMovement>().Qpopup.SetActive(false);
            collision.gameObject.GetComponent<PlayerMovement>().nearbyInteractable = null;
        }
    }

    public void EndInteract()
    {
        thoughtWindow.SetActive(false);

        progress++;
        if(progress > messages.Length - 1)
        {
            progress = 0;
        }
        interacting = false;
    }

    IEnumerator DisplayMessage(string message)
    {
        thoughtWindow.SetActive(true);
        Text newThought = thoughtText.GetComponent<Text>();
        newThought.text = "";
        foreach (char letter in message.ToCharArray())
        {
            newThought.text += letter;
            yield return new WaitForSeconds(0.05f); 
        }
        yield return new WaitForSeconds(1f); //waits a bit before dismissing thought

        EndInteract();
        yield break;
    }
}