using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The main class that talks with the database. All queries go trough this class
/// </summary>
public class BackEndCommunicator {
    private string Protocol = "https://";
    private string URL = "dodo.cah.onl/_php/";

    private static BackEndCommunicator instance;
    public static BackEndCommunicator Instance {
        get {
            if (instance == null) {
                instance = new BackEndCommunicator();
            }
            return instance;
        }
    }

    private BackEndCommunicator() { }

    /// <summary>
    /// This method checks the login of the player.
    /// </summary>
    /// <param name="name"> Username of the player</param>
    /// <param name="password"> Password of the player</param>
    /// <returns> Returns the playerID if valid, else it returns 0.</returns>
    public int Login(string name, string password)
    {
        int playerID = 0;
        string resultString = GetData("read", "player_login", string.Format("us={0}&pw={1}&sesid={2}", name, password, "Uy5ytsn2rMSMX8fD"));
        int.TryParse(resultString, out playerID);
        return playerID;
    }

    /// <summary>
    /// Gets the playerData out of the database.
    /// </summary>
    /// <param name="playerID"> ID of the Player</param>
    /// <param name="sessionID"> SessionID of the Player</param>
    /// <returns> The playerdata object</returns>
    public AvatarData GetPlayerData(int playerID, string sessionID)
    {
        AvatarData playerData = JsonUtility.FromJson<AvatarData>(GetData("read", "player_complete", string.Format("pid={0}&sesid={1}", playerID, sessionID)));
        playerData.SessionID = sessionID;
        playerData.FoundPlayers = JsonUtility.FromJson<IntArray>(GetData("read", "player_foundplayers", string.Format("pid={0}&sesid={1}", playerID, sessionID)));

        return playerData;
    }
    
    /// <summary>
    /// Gets all the npc data out of the database.
    /// </summary>
    /// <param name="npcID"> ID of the npc</param>
    /// <param name="sessionID"> SessionID of the player</param>
    /// <returns> A list of Avatardata which represent all the NPC's</returns>
    public List<AvatarData> GetNPCData(int npcID, string sessionID)
    {
        List<AvatarData> NPCData = new List<AvatarData>();
        string[] NPCs = GetData("read", "npc_ids", string.Format("pid={0}&sesid={1}", npcID, sessionID)).Split('|');
        foreach (string splitstring in NPCs)
        {
            if(splitstring != "")
            {
                NPCData.Add(JsonUtility.FromJson<AvatarData>(splitstring));
            }
        }
        return NPCData;
    }

    /// <summary>
    /// Creates a session in the database. This session is required for connecting with the database. Without one you can't.
    /// </summary>
    /// <param name="playerID"> ID of the player</param>
    /// <returns>The SessionID for use later in the game</returns>
    public string CreateSession(int playerID)
    {
         return GetData("create", "session", string.Format("pid={0}&sesid={1}", playerID, "Uy5ytsn2rMSMX8fD"));
    }

    /// <summary>
    /// This function saves the data at the end of the game.
    /// </summary>
    /// <param name="playerID"> ID of the player</param>
    /// <param name="foundPlayerID"> ID of the player you found</param>
    /// <param name="sessionID"> SessionID of the player</param>
    /// <param name="spawn"> Location of the player</param>
    /// <param name="tutorial">Bool to check if player has to follow tutorial</param>
    public void EndGameSave(int playerID, int foundPlayerID, string sessionID, string spawn, bool tutorial)
    {
        if(foundPlayerID != 0)
        {
            if (!checkFoundPlayer(foundPlayerID))
            {
                GetData("create", "found_player", string.Format("pid={0}&fid={1}&sesid={2}", playerID, foundPlayerID, sessionID));
            }
        }
        GetData("create", "spawn", string.Format("pid={0}&spawn={1}&tut={2}&sesid={3}", playerID, spawn, tutorial, sessionID));
    }

    /// <summary>
    /// Checks if the foundplayer has already been found by the player.
    /// </summary>
    /// <param name="playerID"> The id of the found player.</param>
    /// <returns>(bool) true if the player has been found before. (bool) false if the player has not been found before</returns>
    public bool checkFoundPlayer(int playerID)
    {
        AvatarData avatar = new AvatarData();
        if(DataTracking.currentNPC != null)
        {
            avatar = DataTracking.currentNPC;
        } else
        {
            avatar = DataTracking.randomNPC;
        }

        foreach (int item in DataTracking.playerData.FoundPlayers.intList)
        {
            if(item == avatar.PlayerID) {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 
    /// The query function.
    /// </summary>
    /// <param name="action"> What kind of action do you want to do?</param>
    /// <param name="pageName"> How is the page called?</param>
    /// <param name="parameters"> All parameters required</param>
    /// <returns>The webrequest.text. This contains all text of the webpage</returns>
    private string GetData(string action, string pageName, string parameters)
    {
        WWW webRequest = new WWW(Protocol + URL + action + "/" + pageName + ".php?" + parameters);
        while (!webRequest.isDone)
        {

        }
        return webRequest.text;
    }
}