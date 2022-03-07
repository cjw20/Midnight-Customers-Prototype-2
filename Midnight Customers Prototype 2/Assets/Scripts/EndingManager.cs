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

    
    public void StartEnding()
    {
        timeManager.EndGame();
        endingPhone.SetActive(true);
    }


    public void CultEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        cultEnd.GetComponent<EndingText>().PlayText();
        
    }

    public void DeepOneEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        deepEnd.GetComponent<EndingText>().PlayText();
    }

    public void InvestigatorEnding()
    {
        timeManager.toBlack.FadeIn(3f);
        investigatorEnd.GetComponent<EndingText>().PlayText();
    }
}
