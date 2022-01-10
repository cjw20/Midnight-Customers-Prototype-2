using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebook : MonoBehaviour
{
    // Fields
    bool bookStatus; //true when opened

    // References
    [Header("References")]
    [Tooltip("Reference to the opened book prefab.")]
    public GameObject openedBook;
    
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