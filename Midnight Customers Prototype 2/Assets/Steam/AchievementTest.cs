using Steamworks;
using UnityEngine;

public class AchievementTest : MonoBehaviour
{
    private bool requested;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
