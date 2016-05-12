using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour {
    public string[] items;

    public InputField InputField;
    public GameController gameController;
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
            if(input.Length != 12)
            {
                InputField.text = "";
                loginFailed.SetActive(true);
                return;
            }

            //Send a request to the back-end (login) and retrieve the playerID. IT RETURNS 0 IF LOGIN FAILED
            //2 letters, 7 cijfers, 3 cijfers
            string user;
            user = input.Substring(0, 9);
            string password;
            password = input.Substring(9, 3);
            print(user + "    " + password);

            GameController.playerLogin = BackEndCommunicator.Instance.Login(user, password);
            if(GameController.playerLogin == null)
            {
                InputField.text = "";
                loginFailed.SetActive(true);
            }
            else if(GameController.playerLogin.PlayerID > 0)
            {
                InputField.enabled = false;
                GameController.playerData = new AvatarData();
                //Create Session
                GameController.playerData.SessionID = BackEndCommunicator.Instance.CreateSession(GameController.playerLogin.PlayerID);
                //Get the playerdata
                GameController.playerData = BackEndCommunicator.Instance.GetPlayerData(GameController.playerLogin.PlayerID, GameController.playerData.SessionID);
                //Get the NPCData
                GameController.npcData = BackEndCommunicator.Instance.GetNPCData(GameController.playerLogin.PlayerID, GameController.playerData.SessionID);
                //TODO: Add loadinscreen
                SceneManager.LoadScene("T2");
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
