using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Singleton (add more comments later)
/// </summary>
public class BackEndCommunicator {
    private string Protocol = "https://";
    private string URL = "dodo.cah.onl/Database/";

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
    /// Connects to the back-end and tries to login the player
    /// </summary>
    /// <param name="loginInformation">The string of the combined username and password</param>
    /// <returns>The information of the player. If login didnt succeed, it returns NULL</returns>
    public int Login(string name, string password)
    {
        int playerID = 0;
        string resultString = GetData("read", "player_login", string.Format("us={0}&pw={1}&sesid={2}", name, password, "Uy5ytsn2rMSMX8fD"));
        int.TryParse(resultString, out playerID);
        return playerID;
    }

    public AvatarData GetPlayerData(int playerID, string sessionID)
    {
        string resultString = GetData("read", "player_complete", string.Format("pid={0}&sesid={1}", playerID, sessionID));
        AvatarData playerData = JsonUtility.FromJson<AvatarData>(resultString);

        playerData.SessionID = sessionID;

        resultString = GetData("read", "player_foundplayers", string.Format("pid={0}&sesid={1}", playerID, sessionID));

        playerData.FoundPlayers = stringToIntArray(GetData("read", "player_foundplayers", string.Format("pid={0}&sesid={1}", playerID, sessionID)));
        
        resultString = GetData("read", "player_skills", string.Format("pid={0}&sesid={1}", playerID, sessionID));
        playerData.Skills = resultString.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');
        
        return playerData;
    }

    private AvatarData GetEachNPCData(int playerID, string sessionID)
    {
        string resultString = GetData("read", "player_complete", string.Format("pid={0}&sesid={1}", playerID, sessionID));
        AvatarData npcData = JsonUtility.FromJson<AvatarData>(resultString);
        
        resultString = GetData("read", "player_skills", string.Format("pid={0}&sesid={1}", playerID, sessionID));
        npcData.Skills = resultString.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');

        return npcData;
    }

    public List<AvatarData> GetNPCData(int playerID, string sessionID)
    {
        List<AvatarData> NPCData = new List<AvatarData>();
        int[] resultArray = stringToIntArray(GetData("read", "npc_ids", string.Format("pid={0}&sesid={1}", playerID, sessionID)));

        foreach (int id in resultArray)
        {
            NPCData.Add(Instance.GetEachNPCData(id, sessionID));
        }
        return NPCData;
    }

    public bool CheckTutorial(int playerID, string sessionID)
    {
        string resultString = GetData("read", "tutorial", string.Format("pid={0}&sesid={1}", playerID, sessionID));
        return resultString == "true" ? true : false;
    }

    public string CreateSession(int playerID)
    {
         return GetData("create", "session", string.Format("pid={0}&sesid={1}", playerID, "Uy5ytsn2rMSMX8fD"));
    }

    public void SaveFoundPlayer(int playerID, int foundPLayerID, string sessionID)
    {
        GetData("create", "found_player", string.Format("pid={0}&fid={1}&sesid={2}", playerID, foundPLayerID, sessionID));
    }

    public void SaveSpawnLocation(int playerID, string spawn, string sessionID)
    {
        GetData("create", "spawn", string.Format("pid={0}&spawn={1}&sesid={2}", playerID, spawn, sessionID));
    }

    private string GetData(string action, string pageName, string parameters)
    {
        WWW webRequest = new WWW(Protocol + URL + action + "/" + pageName + ".php?" + parameters);
        Debug.Log(webRequest.url);
        while (!webRequest.isDone)
        {

        }
        return webRequest.text;
    }

    private int[] stringToIntArray(string arr)
    {
        string[] splitRequestResult = arr.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');
        int[] intRequestResult = new int[splitRequestResult.Length];
        for (int i = 0; i < splitRequestResult.Length; i++)
        {
            int.TryParse(splitRequestResult[i], out intRequestResult[i]);
        }
        return intRequestResult;
    }
}