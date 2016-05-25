using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps track of certain data for the game
/// </summary>
public static class DataTracking  {
    //public static PlayerController thePlayer;
    //NPC information for activating a minigame
    public static NPC currentNPC;
    //Player Data Model
    public static AvatarData playerData;
    //Player Login Model
    public static PlayerLogin playerLogin;
    //NPC dictionairy
    public static List<AvatarData> npcData;
    //random avatardata for when player doesnt find a character
    public static AvatarData randomNPC;

    public static void resetGame()
    {
        //Flush static variables of datatracking to prevent mix-up with previous readings.
        DataTracking.playerData = null;
        DataTracking.playerLogin = null;
        DataTracking.npcData = null;
        GameController.playedTime = 0;
        //Back to loginscreen
        SceneManager.LoadScene("Login");
    }
}