using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPManager : MonoBehaviour
{
    // Fields
    public Volume volume;
    DepthOfField dof;

    // References

    public void EnableDepthOfFieldEffect()
    {
        if (volume.profile.TryGet<DepthOfField>(out dof))
        {
            dof.active = true;
        }
    }

    public void DisableDepthOfFieldEffect()
    {
        if (volume.profile.TryGet<DepthOfField>(out dof))
        {
            dof.active = false;
        }
    }
}