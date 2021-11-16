using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeGame : MonoBehaviour
{
    MiniGameControl mgControl;
    LightManager lightManager;
    // Start is called before the first frame update
    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
        lightManager = FindObjectOfType<LightManager>();
    }


    public void Finish()
    {
        StartCoroutine(EndGame()); //only here because cant start coroutine from other classes??
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f); //short delay so player can see light turn on
        lightManager.FixBulb();
        mgControl.EndMiniGame();
        Destroy(this.gameObject);
        yield break;
    }
}
