using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalDisplay : MonoBehaviour
{
    public List<string> journalText;
    [SerializeField] GameObject journal;
    [SerializeField] Text displayText;
    public int journalProgress; //add this to save system
    public bool inJournal;

    public void OpenJournal()
    {
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
        journal.SetActive(false);
        inJournal = false;
    }
}
