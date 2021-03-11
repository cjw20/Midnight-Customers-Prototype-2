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
    [SerializeField] private Transform buttonContainer;

    public float buttonOffset; //how much space between option buttons
    int buttonNumber; //number of buttons currently instantiated

    public CheckoutManager checkoutManager;
    
    public void StartConvo(DialogueContainer convo)
    {
        dialogue = convo;
        //do this after loading the convo?
        var narrativeData = dialogue.NodeLinks.First(); //Entrypoint node
        ProceedToNarrative(narrativeData.TargetNodeGuid);
    }

    public void SetConversation(DialogueContainer convo)
    {
        //call this from checkout trigger to set up right conversation
        dialogue = convo;
    }
    private void ProceedToNarrative(string narrativeDataGUID)
    {
        var text = dialogue.DialogueNodeData.Find(x => x.Guid == narrativeDataGUID).DialogueText;
        var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGuid == narrativeDataGUID);
        StartCoroutine(TypeSentence(ProcessProperties(text), narrativeDataGUID));
        var buttons = buttonContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i].gameObject);
        }
        //check if ending?
        
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
        
        //dialogueText.text = ProcessProperties(text);
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
                button.transform.position = buttonContainer.position + new Vector3(0, buttonOffset * buttonNumber, 0);
                button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName);
                button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGuid));
            }
            
            buttonNumber++;

            if(ProcessProperties(choice.PortName) == "...")
            {
                
                StartCoroutine(WaitForSelection(choice.TargetNodeGuid));
                //Destroy(button);
                //hide button, start wait coroutine for selecting "no option"
                //pass choice as a parameter
            }
        }

        if (buttonNumber == 0)
        {
            //hide dialogue window?
            checkoutManager.EndDialogue();
        }
    }

    IEnumerator WaitForSelection(string targetNodeGuid)
    {
        yield return new WaitForSeconds(10); //waits 10 seconds may want to make shorter?
        ProceedToNarrative(targetNodeGuid);
        yield break;
    }

    IEnumerator TypeSentence(string sentence, string narrativeDataGUID) 
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); //delay goes here
        }
        StartCoroutine(WaitForNewChoices(narrativeDataGUID));
        yield break;
    }
}
