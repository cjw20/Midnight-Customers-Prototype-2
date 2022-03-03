using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNodeData
{
    // Fields
    [Tooltip("Guid.")]
    public string Guid;
    [Tooltip("Text for the dialogue.")]
    public string DialogueText;

    // References
    [Tooltip("Reference to a Vector2 for position.")]
    public Vector2 Position;
}