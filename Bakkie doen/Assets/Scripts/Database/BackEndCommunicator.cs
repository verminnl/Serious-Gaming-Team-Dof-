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
        AvatarData playerData = JsonUtility.FromJson<AvatarData>(GetData("read", "player_complete", string.Format("pid={0}&sesid={1}", playerID, sessionID)));

        playerData.SessionID = sessionID;

        string resultString = GetData("read", "player_foundplayers", string.Format("pid={0}&sesid={1}", playerID, sessionID));

        playerData.FoundPlayers = stringToIntArray(GetData("read", "player_foundplayers", string.Format("pid={0}&sesid={1}", playerID, sessionID)));
        return playerData;
    }

    private AvatarData GetEachNPCData(int playerID, string sessionID)
    {
        return JsonUtility.FromJson<AvatarData>(GetData("read", "player_complete", string.Format("pid={0}&sesid={1}", playerID, sessionID)));
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

    public string CreateSession(int playerID)
    {
         return GetData("create", "session", string.Format("pid={0}&sesid={1}", playerID, "Uy5ytsn2rMSMX8fD"));
    }

    public void EndGameSave(int playerID, int foundPlayerID, string sessionID, string spawn, bool tutorial)
    {
        if(foundPlayerID != 0)
        {
            GetData("create", "found_player", string.Format("pid={0}&fid={1}&sesid={2}", playerID, foundPlayerID, sessionID));
        }
        GetData("create", "spawn", string.Format("pid={0}&spawn={1}&tut={2}&sesid={3}", playerID, spawn, tutorial, sessionID));
        Debug.Log(DataTracking.usedMB);
    }

    private string GetData(string action, string pageName, string parameters)
    {
        WWW webRequest = new WWW(Protocol + URL + action + "/" + pageName + ".php?" + parameters);
        Debug.Log(webRequest.url);
        while (!webRequest.isDone)
        {

        }
        DataTracking.usedMB += webRequest.bytesDownloaded;
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