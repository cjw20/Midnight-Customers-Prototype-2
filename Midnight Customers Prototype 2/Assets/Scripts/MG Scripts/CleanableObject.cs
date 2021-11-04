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
    
    [SerializeField]
    float hitpoints = 5.0f;
    void Start()
    {
        mess = this.gameObject.GetComponent<SpriteRenderer>();
        startingColor = mess.color;
        mopGame = FindObjectOfType<MopGame>();
    }
/*
    // Update is called once per frame
    void Update()
    {
        if (isBeingCleaned && tool.isCleaning)
        {
            passedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1, 0, (passedTime / cleanTime));
            newColor = new Color(startingColor.r, startingColor.g, startingColor.b, currentAlpha);
            mess.color = newColor;
            if (currentAlpha <= 0.1f) //float 
            {
                mopGame.CleanedObject();
                Destroy(this.gameObject);
            }
        }
    } 
*/
    //hitpoints = 5
    // onTrigger, decrement hitpoints
    //check for no hitpoints
    // destroy object
    //refactor mopgame 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In");
        if (collision.CompareTag("Cleaner"))
        {
            isBeingCleaned = true;
        }
    }
    //Helper for Function Above
    void setAlpha() {
        float newAlpha = hitpoints/5;//There's an issue with this line 
        newColor = new Color(startingColor.r, startingColor.g, startingColor.b, newAlpha);
        mess.color = newColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cleaner"))
        {
            if(isBeingCleaned){
                tool = collision.gameObject.GetComponent<CleaningTool>();
                hitpoints-=1;
                if (hitpoints <= 0){
                    mopGame.CleanedObject();
                    Destroy(this.gameObject);//pretty messed up, man
                }
                setAlpha();
            }
            isBeingCleaned = false;
            //add velocity check later
        }
    }
}
