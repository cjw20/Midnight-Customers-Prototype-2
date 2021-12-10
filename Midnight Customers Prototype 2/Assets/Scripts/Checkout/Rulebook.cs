using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebook : MonoBehaviour
{
    public GameObject openedBook;
    bool bookStatus; //true when opened
    
    public void ToggleBook()
    {
        bookStatus = !bookStatus;
        openedBook.SetActive(bookStatus);
    }

    private void OnMouseDown()
    {
        ToggleBook();
    }
}