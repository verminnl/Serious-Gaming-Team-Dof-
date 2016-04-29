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


            //Send a request to the back-end (login) and retrieve the playerID. IT RETURNS 0 IF LOGIN FAILED
            //2 letters, 7 cijfers, 3 cijfers
            GameController.playerLogin = BackEndCommunicator.Instance.Login("dodo", "dodo");
            if(GameController.playerLogin == null)
            {
                print("you fucked up");
            }
            else if(GameController.playerLogin.PlayerID > 0)
            {
                print("You logged in!");
                InputField.enabled = false;

                //Get the playerdata
                GameController.playerData = BackEndCommunicator.Instance.GetPlayerData(GameController.playerLogin.PlayerID);
                //Get the NPCData

                GameController.npcData = BackEndCommunicator.Instance.GetNPCData(GameController.playerLogin.PlayerID);
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
