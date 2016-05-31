using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Net;

/// <summary>
/// This Class handles the complete login procedure 
/// </summary>
public class LoginController : MonoBehaviour {
    public string[] items;

    public InputField InputField;
    public GameObject loginFailed;
    public string[] dialogue;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(InputField.gameObject, null);
        if (!HasConnection())
        {
            print(" Geen internet");
        }
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
            int playerID = BackEndCommunicator.Instance.Login(user, password);
            if(playerID == 0)
            {
                InputField.text = "";
                loginFailed.SetActive(true);
                EventSystem.current.SetSelectedGameObject(InputField.gameObject, null);
                return;
            }
            else if(playerID > 0)
            {
                InputField.enabled = false;
                DataTracking.playerData = new AvatarData();
                //Create Session
                DataTracking.playerData.SessionID = BackEndCommunicator.Instance.CreateSession(playerID);
                //Get the playerdata
                DataTracking.playerData = BackEndCommunicator.Instance.GetPlayerData(playerID, DataTracking.playerData.SessionID);
                DataTracking.playerData.CharacterSprite = SetCharacterSprite(DataTracking.playerData.Character);
                //Get the NPCData
                DataTracking.npcData = BackEndCommunicator.Instance.GetNPCData(playerID, DataTracking.playerData.SessionID);
                foreach (AvatarData npc in DataTracking.npcData)
                {
                    npc.CharacterSprite = SetCharacterSprite(npc.Character);
                    npc.Dialogue = NPCSetDialogue(npc);
                }
                DataTracking.randomNPC = DataTracking.npcData[Random.Range(0, DataTracking.npcData.Count)];
                if (!DataTracking.playerData.Tutorial)
                {
                    if(DataTracking.playerData.SpawnPoint == "")
                    {
                        SceneManager.LoadScene("T2");
                    }
                    else
                    {
                        switch (DataTracking.playerData.SpawnPoint.Substring(0, 2))
                        {
                            case "T0":
                                SceneManager.LoadScene("T0");
                                break;
                            case "T1":
                                SceneManager.LoadScene("T1");
                                break;
                            case "T2":
                                SceneManager.LoadScene("T2");
                                break;
                            case "T3":
                                SceneManager.LoadScene("T3");
                                break;
                        }
                    }
                }
                else
                {
                    SceneManager.LoadScene("Tutorial scene");
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
        dialogue = new string[3];
        dialogue[0] = "Hoi " + DataTracking.playerData.FirstName + ", ik ben " + randomNPC.FirstName + ".";
        if (randomNPC.Skill2 == "" && randomNPC.Skill3 == "")
        {
            dialogue[1] = "Ik ben erg goed in " + randomNPC.Skill1 + ".";
        }
        else if (randomNPC.Skill3 == "")
        {
            dialogue[1] = "Ik ben erg goed in " + randomNPC.Skill1 + " en " + randomNPC.Skill2 + ".";
        }
        else
        {
            dialogue[1] = "Ik ben erg goed in " + randomNPC.Skill1 + ", " + randomNPC.Skill2 + " en " + randomNPC.Skill3 + ".";
        }
        dialogue[2] = "Je vindt me in kamer " + randomNPC.Room + ".";
        return dialogue;
    }

    public static bool HasConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = new WebClient().OpenRead("http://www.google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}