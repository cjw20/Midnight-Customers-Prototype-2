using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialoguePlayer : MonoBehaviour
{
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button choicePrefab;
    [SerializeField] private RectTransform buttonContainer;
    [SerializeField] RectTransform[] buttonPositions;

    public CountdownSlider countdownSlider;

    public float buttonOffset; //how much space between option buttons
    int buttonNumber; //number of buttons currently instantiated

    public CheckoutManager checkoutManager;
    Coroutine lastCourutine;
    //Dependent on editor references being set to children
    public GameObject playerDialoguePanel;
    public GameObject countdownBar;
    bool charDelay;

    private void OnEnable()
    {
        countdownSlider.SetMinMax(0, 6, 6);
    }

    public void StartConvo(DialogueContainer convo)
    {
        dialogue = convo;
        //do this after loading the convo?
        var narrativeData = dialogue.NodeLinks.First(); //Entrypoint node
        playerDialoguePanel.SetActive(true);
        countdownBar.SetActive(true);
        ProceedToNarrative(narrativeData.TargetNodeGuid);
        

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
                
            }

            buttonNumber++;

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
        yield return new WaitForSeconds(6); //waits 10 seconds may want to make shorter?
        
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
                if(charDelay) yield return new WaitForSeconds(0.03f); //delay goes here
            }
            StartCoroutine(WaitForNewChoices(narrativeDataGUID));
            yield break;
        }
        
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Q)){
            charDelay = false;
        }
    }
}
