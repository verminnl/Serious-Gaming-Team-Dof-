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

        int result = 0;

        //Connect to the server
        var webRequest = new WWW(URLToUse);
        while (!webRequest.isDone) //Wait until the request is done
        {

        }

        //Get the result of the web request
        string requestResultString = webRequest.text;

        var test2 = new PlayerLogin() { PlayerID = 1 };
        var test = JsonUtility.ToJson(test2);
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

        PlayerData playerData = null;

        //Connect to the server
        var webRequest = new WWW(URLToUse);
        while (!webRequest.isDone) //Wait until the request is done
        {

        }

        //Get the result of the web request
        string requestResultString = webRequest.text;

        //Convert the result from the request (JSON) to a PlayerData model object.
        playerData = JsonUtility.FromJson<PlayerData>(requestResultString);

        //TODO: Check if all the elements of the parsing went right. if not, treat the process as a failed one (set PlayerData == null)
        return playerData;
    }

    private string GetURL(string action, string pageName)
    {
        return Protocol + URL + action + "/" + pageName + ".php?";
    }

}
