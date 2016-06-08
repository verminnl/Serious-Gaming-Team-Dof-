using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the data on the scene that appears at the end of the game
/// </summary>
public class EndGameScene : MonoBehaviour {
    //Farewell text box of screen
    public Text textBox;
    //Name box of the NPC
    public Text npcNameBox;
    //Sprite of the NPC
    public Image npcSprite;
    //Job box no.1 of the NPC
    public Text npcJobBox;
    //Skills box no.1 of the NPC
    public Text npcSkillsBox1;
    //Skills box no.2 of the NPC
    public Text npcSkillsBox2;
    //Skills box no.3 of the NPC
    public Text npcSkillsBox3;
    //Card image
    public GameObject card;
    //Check if the screen is active
    private bool isActive;
    //Local avatardata to set endgame screen
    private AvatarData foundPlayer;

	// Use this for initialization
	void Start () {
        //Sets the details of the encountered NPC on the screen
        foundPlayer = DataTracking.currentNPC == null ? DataTracking.randomNPC : DataTracking.currentNPC;
        npcNameBox.text = foundPlayer.FullName;
        npcSprite.sprite = foundPlayer.NPCSprite;
        textBox.text = textBox.text + DataTracking.playerData.FirstName;
        if(foundPlayer.Element == "blue")
        {
            card.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bluecard");
        }
        npcJobBox.text = foundPlayer.Job;
        npcSkillsBox1.text = foundPlayer.Skill1;
        npcSkillsBox2.text = foundPlayer.Skill2;
        if (foundPlayer.Skill3 != null)
        {
            npcSkillsBox3.text = foundPlayer.Skill3;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //When the player presses the {Enter key or keypadenter} when this gameobject is active, ends the current game session
        if (isActive)
        {
            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            {
                BackEndCommunicator.Instance.EndGameSave(DataTracking.playerData.PlayerID, foundPlayer.PlayerID, DataTracking.playerData.SessionID, DataTracking.playerData.SpawnPoint, DataTracking.playerData.Tutorial);
                DataTracking.resetGame();
            }
        }
	}

    /// <summary>
    /// Activates this screen
    /// </summary>
    public void ActivateScreen()
    {
        gameObject.SetActive(true);
        isActive = true;
    }
}
