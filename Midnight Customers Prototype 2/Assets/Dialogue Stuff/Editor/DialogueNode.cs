using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class DialogueNode : Node
{
    // Fields
    public string GUID;

    public string dialogueText;

    public bool entryPoint = false;
}