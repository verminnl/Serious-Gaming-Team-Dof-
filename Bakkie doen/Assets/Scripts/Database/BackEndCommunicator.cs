using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Singleton (add more comments later)
/// </summary>
public class BackEndCommunicator {

    private static BackEndCommunicator instance;

    public static BackEndCommunicator Instance {
        get {
            if (instance == null) {
                instance = new BackEndCommunicator();
            }

            return instance;
        }
    }

    public string Protocol = "http://";
    public string URL = "localhost/Database/";
    private BackEndCommunicator()
    {
        //Set specific stuff here if needed
    }

    /// <summary>
    /// Connects to the back-end and tries to login the player
    /// </summary>
    /// <param name="loginInformation">The string of the combined username and password</param>
    /// <returns>The information of the player. If login didnt succeed, it returns NULL</returns>
    public PlayerLogin Login(string name, string password)
    {
        //Set up the URL
        string basicURL = GetURL("read", "player_login");
        string parameters = string.Format("us={0}&pw={1}", name,password);
        string URLToUse = basicURL + parameters + "&sesid=Uy5ytsn2rMSMX8fD";
        
        //Connect to the server
        var webRequest = new WWW(URLToUse);
        while (!webRequest.isDone) //Wait until the request is done
        {

        }

        //Get the result of the web request
        string requestResultString = webRequest.text;
        
        // Decode from json
        PlayerLogin decodedPlayerLoginObject = JsonUtility.FromJson<PlayerLogin>(requestResultString);
                
        return decodedPlayerLoginObject;
        
    }

    public AvatarData GetPlayerData(int playerID, string sessionID)
    {
        // Player Data step 1 webrequest
        //Set up the URL
        string basicURL = GetURL("read", "player_complete");
        string parameters = string.Format("pid={0}", playerID);
        string URLToUse = basicURL + parameters + "&sesid=" + sessionID;

        //Connect to the server
        var webRequestPlayerData = new WWW(URLToUse);
        // Player Data step 1 webrequest end

        // Player Data step 2 Found players webrequest
        basicURL = GetURL("read", "player_foundplayers");
        URLToUse = basicURL + parameters + "&sesid=" + sessionID; ;
        
        var webRequestPlayerFoundPlayers = new WWW(URLToUse);
        // Player Data step 2 Found players webrequest end

        // Player Data step 3 Skills webrequest
        basicURL = GetURL("read", "player_skills");
        URLToUse = basicURL + parameters + "&sesid=" + sessionID; ;
        
        var webRequestPlayerSkills = new WWW(URLToUse);
        // Player Data step 3 Skills webrequest end

        // Wait for the requests to be done
        while (!webRequestPlayerData.isDone || !webRequestPlayerFoundPlayers.isDone || !webRequestPlayerSkills.isDone) //Wait until the request is done
        {

        }
        
        // Player Data step 2, web requests to strings
        // Player Data
        string requestResultStringPlayerData = webRequestPlayerData.text;
        // Player FoundPlayers
        string requestResultStringFoundPlayers = webRequestPlayerFoundPlayers.text;
        // Player Skills
        string requestResultStringPlayerSkills = webRequestPlayerSkills.text;
        // Player Data step 2, web requests to strings end

        // Player Data step 3, strings to datamodel
        // Player Data
        //Convert the result from the request (JSON) to a PlayerData model object.
        AvatarData playerData = JsonUtility.FromJson<AvatarData>(requestResultStringPlayerData);
        
        // PlayerFound Players
        //Convert the string into something useable for c#
        string[] splitRequestResult = requestResultStringFoundPlayers.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');
        
        //change the string array to an int array
        int[] intRequestResult = new int[splitRequestResult.Length];
        for (int i = 0; i < splitRequestResult.Length; i++)
        {
            int.TryParse(splitRequestResult[i], out intRequestResult[i]);
        }
        //Set the players FoundPlayers;
        playerData.FoundPlayers = intRequestResult;
        
        // Skills
        //Convert the string into something useable for c#
        splitRequestResult = requestResultStringPlayerSkills.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');
        
        //Set the players FoundPlayers;
        playerData.Skills = splitRequestResult;

        // Return the playerDataModel
        return playerData;
    }

    public List<AvatarData> GetNPCData(int playerID, string sessionID)
    {
        List<AvatarData> NPCData = new List<AvatarData>();

        //Set up the URL
        string basicURL = GetURL("read", "npc_ids");
        string parameters = string.Format("pid={0}", playerID);
        string URLToUse = basicURL + parameters + "&sesid=" + sessionID; ;

        var webRequestAllNPCIDs = new WWW(URLToUse);

        // Wait for the requests to be done
        while (!webRequestAllNPCIDs.isDone) //Wait until the request is done
        {

        }
        string webRequestAllNPCIDsText = webRequestAllNPCIDs.text;
        //Convert the string into something useable for c#
        string[] splitRequestResult = webRequestAllNPCIDsText.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');

        //change the string array to an int array
        int[] intRequestResult = new int[splitRequestResult.Length];
        for (int i = 0; i < splitRequestResult.Length; i++)
        {
            int.TryParse(splitRequestResult[i], out intRequestResult[i]);
        }

        foreach (int id in intRequestResult)
        {
            NPCData.Add(BackEndCommunicator.Instance.GetPlayerData(id, sessionID));
        }
        Debug.Log("hoaofasdf");

        return NPCData;
    }

    public bool CheckTutorial(int playerID, string sessionID)
    {
        //Set up the URL
        string basicURL = GetURL("read", "tutorial");
        string parameters = string.Format("pid={0}", playerID);
        string URLToUse = basicURL + parameters + "&sesid=" + sessionID; ;

        var webRequestTutorial = new WWW(URLToUse);

        // Wait for the requests to be done
        while (!webRequestTutorial.isDone) //Wait until the request is done
        {

        }
        string webRequestTutorialText = webRequestTutorial.text;
        if (webRequestTutorialText == "true")
        {
            return true;
        }
        return false;
    }

    public string CreateSession(int playerID)
    {
        // Set up the URL
        string basicURL = GetURL("create", "session");
        string parameters = string.Format("pid={0}", playerID);
        string URLToUse = basicURL + parameters + "&sesid=Uy5ytsn2rMSMX8fD";

        var webRequestCreateSession = new WWW(URLToUse);

        // Wait for the requests to be done
        while (!webRequestCreateSession.isDone) //Wait until the request is done
        {

        }
        string webRequestCreateSessionText = webRequestCreateSession.text;

        return webRequestCreateSessionText;
    }

    private string GetURL(string action, string pageName)
    {
        return Protocol + URL + action + "/" + pageName + ".php?";
    }
}