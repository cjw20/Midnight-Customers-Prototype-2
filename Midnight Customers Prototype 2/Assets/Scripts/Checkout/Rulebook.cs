using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rulebook : MonoBehaviour
{
    // Fields
    bool bookStatus;

    // References
    [Header("References")]
    [Tooltip("Reference to the opened book prefab.")]
    public GameObject openedBook;
    [Tooltip("Reference to the SoundManager.")]
    [SerializeField] SoundManager soundManager;
    [SerializeField] Sprite image_one;
    [SerializeField] Sprite image_two;
    [SerializeField] Sprite image_three;
    [SerializeField] Sprite image_four;
    int index = 0;
    
    public void ToggleBook()
    {
        if (!bookStatus)
        {
            soundManager.PlayPageTurnSound();
        }
        else
        {
            soundManager.PlayBookCloseSound();
        }
        bookStatus = !bookStatus;
        openedBook.SetActive(bookStatus);
    }

    public void OpenBook(){
        bookStatus = true;
        openedBook.SetActive(bookStatus);
    }
    
    public void NextPage(){

        Image current_image = openedBook.GetComponent<Image>();
        switch(index){
            case 0: 
                current_image.sprite = image_two;
                break;
            case 1:
                current_image.sprite = image_three;
                break;
            case 2:
                current_image.sprite = image_four;
                break;
            case 3:
                current_image.sprite = image_one;
                index=-1;
                openedBook.SetActive(false);
                break;

            default:
                break;
        }
        index++;
        //set page
        //if page is last, close
        //image references
    }

    private void OnMouseUp()
    {
        OpenBook();
    }
}