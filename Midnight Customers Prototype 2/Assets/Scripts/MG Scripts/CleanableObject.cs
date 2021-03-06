using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanableObject : MonoBehaviour
{
    bool isBeingCleaned;
    CleaningTool tool;
    SpriteRenderer mess;
    public float cleanTime;
    float passedTime;
    public float currentAlpha;
    Color startingColor;
    public Color newColor;

    MopGame mopGame;
    
    void Start()
    {
        mess = this.gameObject.GetComponent<SpriteRenderer>();
        startingColor = mess.color;
        mopGame = FindObjectOfType<MopGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingCleaned && tool.isCleaning)
        {
            passedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1, 0, (passedTime / cleanTime));
            newColor = new Color(startingColor.r, startingColor.g, startingColor.b, currentAlpha);
            mess.color = newColor;
            if (currentAlpha <= 0)
            {
                mopGame.CleanedObject();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cleaner"))
        {
            isBeingCleaned = true;
            tool = collision.gameObject.GetComponent<CleaningTool>();
            //add velocity check later
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cleaner"))
        {
            isBeingCleaned = false;
            //add velocity check later
        }
    }
}
