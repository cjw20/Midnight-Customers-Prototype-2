using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;

    [SerializeField] GameObject cultEnd;
    [SerializeField] GameObject deepEnd;
    [SerializeField] GameObject investigatorEnd;
    [SerializeField] GameObject endingPhone;

    EndingText activeEnding;

    public void StartEnding()
    {
        timeManager.EndGame();
        endingPhone.SetActive(true);
        GameControl.control.SetComplete();
    }


    public void CultEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        activeEnding = cultEnd.GetComponent<EndingText>();
        activeEnding.PlayText();
        
    }

    public void DeepOneEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        activeEnding = deepEnd.GetComponent<EndingText>();
        activeEnding.PlayText();
    }

    public void InvestigatorEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        activeEnding = investigatorEnd.GetComponent<EndingText>();
        activeEnding.PlayText();
    }

    public void OnContinueButton()
    {
        activeEnding.waitingForConfirm = false;
        //this function here so button function does not have to be set separately for each ending
    }
}
