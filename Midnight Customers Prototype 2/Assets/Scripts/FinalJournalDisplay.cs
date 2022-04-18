using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalJournalDisplay : MonoBehaviour
{
    // Fields
    [Tooltip("List of text for the journal.")]

    // [TextArea (4,50)]
    public List<string> journalText;
    [Tooltip("Amount of progress in the journal.")]
    public int journalProgress; //add this to save system
    [Tooltip("Whether the journal is currently open or not.")]
    public bool inJournal;

    // References
    [Header("References")]
    [Tooltip("Reference to the journal object.")]
    [SerializeField] GameObject journal;
    [Tooltip("Reference to the text object to be displayed.")]
    [SerializeField] Text displayText;
    [Tooltip("Reference to the SoundManager.")]
    [SerializeField] SoundManager soundManager;

    public void OpenJournal(int day)
    {
        journalProgress = day-1;
        if (journalProgress >= 19) return;
        soundManager.PlayPageTurnSound();
        inJournal = true;
        journal.SetActive(true);
        displayText.text = journalText[journalProgress];
    }

  public void IncrementPage()
  {
    
    if (journalProgress >= 19) return;
    journalProgress += 1;
    soundManager.PlayPageTurnSound();
    displayText.text = journalText[journalProgress];
  }
  public void DecrementPage()
  {
    if (journalProgress <= 0) return;
    journalProgress -= 1;
    soundManager.PlayPageTurnSound();
    displayText.text = journalText[journalProgress];
  }

    public void CloseJournal()
    {
        soundManager.PlayBookCloseSound();
        journal.SetActive(false);
        inJournal = false;
    }

    public void OpenJournal()
    {
      inJournal = true;
      journalProgress = 0;
      displayText.text = journalText[journalProgress];
    }
}