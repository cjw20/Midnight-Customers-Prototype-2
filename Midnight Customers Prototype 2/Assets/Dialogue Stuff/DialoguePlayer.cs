using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    // Fields
    bool charDelay;
    float charDelaySpeed = 0.03f; // Determines typing speed for dialogue
    int buttonNumber; //number of buttons currently instantiated
    bool dyslexicToggle;
    [Tooltip("How much space between option buttons.")]
    public float buttonOffset;
    [Tooltip("Countdown slider speed.")]
    public int slideSpeed = 6;

    // References
    private PlayerInput playerInput; //asset that has player controls
    [Header("UI References")]
    [Tooltip("Reference to a DialogueContainer class instance.")]
    [SerializeField] private DialogueContainer dialogue;
    [Tooltip("Reference to a Text object for the dialogue text.")]
    [SerializeField] private Text dialogueText;
    [Tooltip("Reference to a Button object for choices.")]
    [SerializeField] private Button choicePrefab;
    [Tooltip("Reference to a RectTransform for the button container.")]
    [SerializeField] private RectTransform buttonContainer;
    [Tooltip("Reference to a list of RectTransforms for the button positions.")]
    [SerializeField] RectTransform[] buttonPositions;
    [Tooltip("Reference to the open dyslexic Font object.")]
    [SerializeField] Font openDyslexic;
    [Tooltip("Reference to the CountdownSlider.")]
    public CountdownSlider countdownSlider;
    [Tooltip("Reference to the CheckoutManager.")]
    public CheckoutManager checkoutManager;
    Coroutine lastCourutine;
    //Dependent on editor references being set to children
    [Tooltip("Reference to the player dialogue panel object.")]
    public GameObject playerDialoguePanel;
    [Tooltip("Reference to the countdown bar object.")]
    public GameObject countdownBar;
    
    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        countdownSlider.SetMinMax(0, slideSpeed, 6);
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    
    public void StartConvo(DialogueContainer convo, Font dialogueFont)
    {
        dialogue = convo;
        //do this after loading the convo?
        var narrativeData = dialogue.NodeLinks.First(); //Entrypoint node
        playerDialoguePanel.SetActive(true);
        countdownBar.SetActive(true);
        ProceedToNarrative(narrativeData.TargetNodeGuid);
        if(!dyslexicToggle) dialogueText.font = dialogueFont;
        else dialogueText.font = openDyslexic;
    }

    public void SetConversation(DialogueContainer convo)
    {
        //call this from checkout trigger to set up right conversation
        dialogue = convo;
    }

    private void ProceedToNarrative(string narrativeDataGUID)
    {
        if(lastCourutine != null)
        {
            StopCoroutine(lastCourutine);
            countdownSlider.Reset();
            lastCourutine = null;
        }
        
        var text = dialogue.DialogueNodeData.Find(x => x.Guid == narrativeDataGUID).DialogueText;
        var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGuid == narrativeDataGUID);
        
        var buttons = buttonContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        //check if ending?
        //if ... end wait couroutine?
        StartCoroutine(TypeSentence(ProcessProperties(text), narrativeDataGUID));
    }

    private string ProcessProperties(string text)
    {
        foreach (var exposedProperty in dialogue.ExposedProperties)
        {
            text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);
        }
        return text;
    }

    IEnumerator WaitForNewChoices(string narrativeDataGUID)
    {
        yield return new WaitForSeconds(1);
        DisplayNewOptions(narrativeDataGUID);
        yield break;
    }

    void DisplayNewOptions(string narrativeDataGUID)
    {
        var text = dialogue.DialogueNodeData.Find(x => x.Guid == narrativeDataGUID).DialogueText;
        var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGuid == narrativeDataGUID);
        
        var buttons = buttonContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        buttonNumber = 0;

        foreach (var choice in choices)
        {
            if(ProcessProperties(choice.PortName) != "...")
            {
                var button = Instantiate(choicePrefab, buttonContainer);
                //button.transform.position = buttonContainer.position + new Vector3(0, (-buttonOffset * (buttonNumber - 1)), 0); //add offset that switches between above and below?
                button.transform.position = buttonPositions[buttonNumber].position;
                button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName);
                button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGuid));
                buttonNumber++;  //moved this here in hopes it will stop breaking when ... isnt last option
            }

           

            if (ProcessProperties(choice.PortName) == "...")
            {                
                lastCourutine = StartCoroutine(WaitForSelection(choice.TargetNodeGuid));
            }
        }

        if (buttonNumber == 0) //inert? tests with Debug.Log nested inside never got called
        {
            //hide dialogue window?
            checkoutManager.EndDialogue(0);
        }
    }

    IEnumerator WaitForSelection(string targetNodeGuid)
    {
        countdownSlider.StartCount();
        yield return new WaitForSeconds(slideSpeed); //waits 10 seconds may want to make shorter?
        
        ProceedToNarrative(targetNodeGuid);
        countdownSlider.Reset();
        yield break;
    }

    IEnumerator TypeSentence(string sentence, string narrativeDataGUID) 
    {
        //This is how the game knows when a conversation ends! The ending nodes MUST begin with + or -
        if(sentence.Substring(0,1) == "+" || sentence.Substring(0, 1) == "-")
        {
            //May cause issues down the line if there are relationship changes mid conversation or starts with above characters
            playerDialoguePanel.SetActive(false);
            countdownBar.SetActive(false);
            int relationshipChange = int.Parse(sentence); //gets change value from string. May need + / - extra
            
            if(sentence.Substring(0,1) == "-")
            {
                relationshipChange *= -1; //may not need this if parse recognizes negative
            }
            yield return new WaitForSeconds(0.5f); //makes dialogue not end right away
            checkoutManager.EndDialogue(relationshipChange); //This is what ends the conversation
            //add or subtract characters relationship score
            yield break;
        }
        else
        {
            charDelay = true;
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                if(charDelay) yield return new WaitForSeconds(charDelaySpeed); //delay goes here
            }
            StartCoroutine(WaitForNewChoices(narrativeDataGUID));
            yield break;
        }
    }

    void Update(){
        if (playerInput.Checkout.Skip.triggered){
            charDelay = false;
        }
    }

    public void SetDelay(int delayLevel){
        if(delayLevel == 0) charDelaySpeed = 0.0f;
        if(delayLevel == 1) charDelaySpeed = 0.015f;
        if(delayLevel == 2) charDelaySpeed = 0.03f;
        if(delayLevel == 3) charDelaySpeed = 0.1f;
    }

    public void ToggleDyslexicFont(bool isOn){
        dyslexicToggle = isOn;
    }
}