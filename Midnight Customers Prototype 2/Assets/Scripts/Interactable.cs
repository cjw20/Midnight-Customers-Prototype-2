using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    bool inRange;
    bool interacting;

    [SerializeField] string[] messages;
    public int progress;

    [SerializeField] GameObject thoughtText;
    [SerializeField] GameObject thoughtWindow;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            if (inRange && !interacting)
            {
                interacting = true;
                StartCoroutine(DisplayMessage(messages[progress]));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            collision.gameObject.GetComponent<PlayerMovement>().Qpopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            collision.gameObject.GetComponent<PlayerMovement>().Qpopup.SetActive(false);
        }
    }

    public void EndInteract()
    {
        thoughtWindow.SetActive(false);

        progress++;
        if(progress > messages.Length - 1)
        {
            progress--;
        }
        interacting = false;
    }

    IEnumerator DisplayMessage(string message)
    {
        thoughtWindow.SetActive(true);
        Text newThought = thoughtText.GetComponent<Text>();
        newThought.text = "";
        foreach (char letter in message.ToCharArray())
        {
            newThought.text += letter;
            yield return new WaitForSeconds(0.05f); 
        }
        yield return new WaitForSeconds(1f); //waits a bit before dismissing thought

        EndInteract();
        yield break;
    }
}
