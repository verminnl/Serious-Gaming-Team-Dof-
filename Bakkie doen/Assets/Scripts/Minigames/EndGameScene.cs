using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the data on the scene that appears at the end of the game
/// </summary>
public class EndGameScene : MonoBehaviour {
    //Card box of the NPC
    public Image npcCardBox;
    //Name box of the NPC
    public Text npcNameBox;
    //Sprite of the NPC
    public Image npcSprite;
    //Farewell text box of screen
    public Text textBox;
    //Card image
    public GameObject card;
    //Time length that the screen should be active
    public float screenDuration;
    //Time that the screen is active
    private float timeActive;
    //Check if the screen is active
    private bool isActive;

	// Use this for initialization
	void Start () {

        npcNameBox.text = DataTracking.currentNPC.avatar.FullName;
        npcSprite.sprite = DataTracking.currentNPC.avatar.CharacterSprite;
        textBox.text = textBox.text + DataTracking.playerData.FirstName;
        if(DataTracking.currentNPC.avatar.Element == "blue")
        {
            card.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardW basis");
        }
        

	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive > screenDuration)
            {
                BackEndCommunicator.Instance.EndGameSave(DataTracking.playerData.PlayerID, DataTracking.currentNPC.avatar.PlayerID, DataTracking.playerData.SessionID, DataTracking.playerData.SpawnPoint, DataTracking.playerData.Tutorial);
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
