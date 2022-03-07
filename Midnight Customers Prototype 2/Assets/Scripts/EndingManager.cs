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

    }

    public void DeepOneEnding()
    {

    }

    public void InvestigatorEnding()
    {

    }
}
