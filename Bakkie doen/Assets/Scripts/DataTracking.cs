using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps track of certain data for the game
/// </summary>
public class DataTracking : MonoBehaviour {
    //public static PlayerController thePlayer;
    //NPC information for activating a minigame
    public static NPCController theNPC;
    //Check if the gameobject already exists in the scene
    private static bool dataTrackingExists;

    //Player Data Model
    public static AvatarData playerData;
    //Player Login Model
    public static PlayerLogin playerLogin;
    //NPC dictionairy
    public static List<AvatarData> npcData;

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

    public static void resetGame()
    {
        //Flush static variables of datatracking to prevent mix-up with previous readings.
        DataTracking.playerData = null;
        DataTracking.playerLogin = null;
        DataTracking.npcData = null;
        DataTracking.theNPC = null;
        GameController.playedTime = 0;
        //Back to loginscreen
        SceneManager.LoadScene("Login");
    }
}
