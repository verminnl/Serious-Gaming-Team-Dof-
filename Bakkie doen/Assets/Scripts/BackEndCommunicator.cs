using UnityEngine;
using System.Collections;


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
        string URLToUse = basicURL + parameters;
        
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

    public PlayerData GetPlayerData(int playerID)
    {
        //Set up the URL
        string basicURL = GetURL("read", "player_complete");
        string parameters = string.Format("pid={0}", playerID);
        string URLToUse = basicURL + parameters;

        //Connect to the server
        var webRequest = new WWW(URLToUse);
        while (!webRequest.isDone) //Wait until the request is done
        {

        }

        //Get the result of the web request
        string requestResultString = webRequest.text;

        //Convert the result from the request (JSON) to a PlayerData model object.
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(requestResultString);

        //Set up the URL
        basicURL = GetURL("read", "player_foundplayers");
        URLToUse = basicURL + parameters;

        //Connect to the server
        webRequest = new WWW(URLToUse);
        while (!webRequest.isDone) //Wait until the request is done
        {

        }

        //Get the result of the web request
        requestResultString = webRequest.text;
        //TODO: Split result string, filter string for double info, into int[][]

        //Convert the result from the request (JSON) to a PlayerData model object.
        string[] splitRequestResult = requestResultString.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(',');
        //int[] intRequestResult = int.TryParse(intRequestResult, playerData.FoundPlayers);
        //playerData.FoundPlayers = int.TryParse(requestResultString.Replace(")(", ",").Replace("(", "").Replace(")", "").Split(','), playerData.FoundPlayers);
        //playerData.FoundPlayers = JsonUtility.FromJson<int[]>(requestResultString);
        //ebug.Log(playerData.FoundPlayers);
        //playerData.FoundPlayers = JsonUtility.FromJson<int[][]>(requestResultString);
        //Debug.Log(playerData.FoundPlayers);
        //TODO: Check if all the elements of the parsing went right. if not, treat the process as a failed one (set PlayerData == null)
        return playerData;
    }

    private string GetURL(string action, string pageName)
    {
        return Protocol + URL + action + "/" + pageName + ".php?";
    }

}
