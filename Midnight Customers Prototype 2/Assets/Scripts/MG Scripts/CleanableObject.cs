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
    Vector4 startingColor;
    // Start is called before the first frame update
    void Start()
    {
        mess = this.gameObject.GetComponent<SpriteRenderer>();
        startingColor = mess.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingCleaned && tool.isCleaning)
        {
            passedTime += Time.deltaTime;
            mess.material.color = new Vector4(startingColor.w, startingColor.x, startingColor.y, Mathf.Lerp(255, 0, (passedTime / cleanTime)));

            if(mess.material.color.a <= 0)
            {
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
