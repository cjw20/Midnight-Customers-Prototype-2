using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeLinkData 
{
    // Fields
    [Tooltip("Base node guid.")]
    public string BaseNodeGuid;
    [Tooltip("Port name.")]
    public string PortName;
    [Tooltip("Target node guid.")]
    public string TargetNodeGuid;
}