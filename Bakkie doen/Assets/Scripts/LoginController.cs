using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour {
    public string[] items;

    public InputField InputField;
    public GameObject loginFailed;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(InputField.gameObject, null);
    }
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            //Get the input of the player
            string input = InputField.text;
            if(input.Length != 10)
            {
                InputField.text = "";
                loginFailed.SetActive(true);
                return;
            }

            //Send a request to the back-end (login) and retrieve the playerID. IT RETURNS 0 IF LOGIN FAILED
            //7 cijfers, 3 cijfers
            string user;
            user = input.Substring(0, 7);
            Debug.Log(user);
            string password;
            password = input.Substring(7, 3);
            Debug.Log(password);
            print(user + "    " + password);

            DataTracking.playerLogin = BackEndCommunicator.Instance.Login(user, password);
            if(DataTracking.playerLogin == null)
            {
                InputField.text = "";
                loginFailed.SetActive(true);
            }
            else if(DataTracking.playerLogin.PlayerID > 0)
            {
                InputField.enabled = false;
                DataTracking.playerData = new AvatarData();
                //Create Session
                DataTracking.playerData.SessionID = BackEndCommunicator.Instance.CreateSession(DataTracking.playerLogin.PlayerID);
                //Get the playerdata
                DataTracking.playerData = BackEndCommunicator.Instance.GetPlayerData(DataTracking.playerLogin.PlayerID, DataTracking.playerData.SessionID);
                //Get tutorial
                DataTracking.playerData.tutorial = BackEndCommunicator.Instance.CheckTutorial(DataTracking.playerLogin.PlayerID, DataTracking.playerData.SessionID);
                //Get the NPCData
                DataTracking.npcData = BackEndCommunicator.Instance.GetNPCData(DataTracking.playerLogin.PlayerID, DataTracking.playerData.SessionID);
                //TODO: Add loadinscreen
                if (DataTracking.playerData.tutorial)
                {
                    SceneManager.LoadScene("Tutorial scene");
                }
                else {
                    SceneManager.LoadScene("T2");
                }
            }
        }
	}

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
