using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour {
    public string[] items;

    public InputField InputField;
    public GameObject loginFailed;
    public string[] dialogue;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(InputField.gameObject, null);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Get the input of the player
            string input = InputField.text;
            input = "82801888123";
            string user;
            string password;
            if (input.Length == 10)
            {
                user = input.Substring(0, 7);
                password = input.Substring(7, 3);
            }
            else if(input.Length == 11)
            {
                user = input.Substring(0, 8);
                password = input.Substring(8, 3);
            }
            else
            {
                InputField.text = "";
                loginFailed.SetActive(true);   
                EventSystem.current.SetSelectedGameObject(InputField.gameObject, null);
                return;
            }

            //Send a request to the back-end (login) and retrieve the playerID. IT RETURNS 0 IF LOGIN FAILED
            //7 cijfers, 3 cijfers
            // of 8 cijfers, 3 cijfers
            
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
                DataTracking.playerData.CharacterSprite = SetCharacterSprite(DataTracking.playerData.Character);
                //Get tutorial
                DataTracking.playerData.tutorial = BackEndCommunicator.Instance.CheckTutorial(DataTracking.playerLogin.PlayerID, DataTracking.playerData.SessionID);
                //Get the NPCData
                DataTracking.npcData = BackEndCommunicator.Instance.GetNPCData(DataTracking.playerLogin.PlayerID, DataTracking.playerData.SessionID);
                foreach (AvatarData npc in DataTracking.npcData)
                {
                    npc.CharacterSprite = SetCharacterSprite(npc.Character);
                    npc.Dialogue = NPCSetDialogue(npc);
                }
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

    public Sprite SetCharacterSprite(string character)
    {
        Sprite sprite = new Sprite();
        if (Resources.Load<Sprite>("Characters/" + character))
        {
            sprite = Resources.Load<Sprite>("Characters/" + character);
        }
        return sprite;
    }

    public string[] NPCSetDialogue(AvatarData randomNPC)
    {
        string skills = "";
        dialogue = new string[3];
        dialogue[0] = "Hallo " + DataTracking.playerData.FirstName + ", ik ben " + randomNPC.FirstName + ".";
        dialogue[1] = "Mijn kamer nummer is " + randomNPC.Room + ".";

        for (int i = 0; i != randomNPC.Skills.Length; i++)
        {
            if (i == randomNPC.Skills.Length - 1)
            {
                skills += "en " + randomNPC.Skills[i] + ".";
            }
            if (i == 0)
            {
                skills += randomNPC.Skills[i];
            }
            else
            {
                skills += ", " + randomNPC.Skills[i];
            }
        }
        dialogue[2] = "Ik kan " + skills;
        return dialogue;
    }
}
