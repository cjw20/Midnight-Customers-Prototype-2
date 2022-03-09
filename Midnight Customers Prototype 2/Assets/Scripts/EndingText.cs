using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] endingContents;
    public int showArtTiming; //how far into array to switch from black screen to full art

    public bool waitingForConfirm = true;

    [SerializeField] GameObject endingWindow;
    [SerializeField] Text endingTextDisplay;
    [SerializeField] TimeManager timeManager;
    SpriteRenderer spriteRenderer;
    public void PlayText()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();   
        StartCoroutine(DisplayEnd());
        
    }

    IEnumerator DisplayEnd()
    {
        yield return new WaitForSeconds(3f); //waits for fade to finish before displaying text
        endingWindow.SetActive(true);
        int i = 0; //for tracking progress through ending

        foreach(string message in endingContents)
        {
            endingTextDisplay.text = "";
            if(i == showArtTiming)
            {
                timeManager.toBlack.FadeOut(2f); //hides blackscreen
                spriteRenderer.enabled = true;
            }
            foreach (char letter in message.ToCharArray())
            {
                endingTextDisplay.text += letter;
                yield return new WaitForSeconds(0.05f);
            }

            while (waitingForConfirm)
            {
                yield return null; //prevents text from moving on until after player clicks to continue
            }
            waitingForConfirm = true; //resets confirmation
        }

        timeManager.toBlack.FadeIn(5f);
        SceneManager.LoadScene("Credits");
        //play credits
        yield break;
    }

    
}
