using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalDisplay : MonoBehaviour
{
    // Fields
    public List<string> journalText;
    public int journalProgress; //add this to save system
    public bool inJournal;

    // References
    [SerializeField] GameObject journal;
    [SerializeField] Text displayText;
    [SerializeField] SoundManager soundManager;

    public void OpenJournal()
    {
        soundManager.PlayPageTurnSound();
        inJournal = true;
        journal.SetActive(true);
        displayText.text = journalText[journalProgress];
        journalProgress++;
        if(journalProgress >= journalText.Count)
        {
            journalProgress--;
        }
    }

    public void CloseJournal()
    {
        soundManager.PlayBookCloseSound();
        journal.SetActive(false);
        inJournal = false;
    }
}