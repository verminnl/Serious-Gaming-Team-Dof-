using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps track of certain data for the game
/// </summary>
public class PlayerActionDataTracking : MonoBehaviour {
    //NPC information for activating a minigame
    public static NPCController theNPC;
    //Check if the gameobject already exists in the scene
    private static bool dataTrackingExists;

    // Use this for initialization
    void Start()
    {
        //Don't destroy gameobject when changing scene
        if (!dataTrackingExists)
        {
            dataTrackingExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
