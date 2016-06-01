using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps track of certain data for the game
/// </summary>
public static class DataTracking  {
    //NPC information for activating a minigame
    public static AvatarData currentNPC;
    //Player Data Model
    public static AvatarData playerData;
    //NPC dictionairy
    public static List<AvatarData> npcData;
    //random avatardata for when player doesnt find a character
    public static AvatarData randomNPC;
    //Floor change
    public static string previousFloor;

    public static void resetGame()
    {
        //Flush static variables of datatracking to prevent mix-up with previous readings.
        currentNPC = null;
        playerData = null;
        npcData = null;
        randomNPC = null;
        previousFloor = null;
        GameController.playedTime = 0;
        //Back to loginscreen
        SceneManager.LoadScene("Login");
    }
}