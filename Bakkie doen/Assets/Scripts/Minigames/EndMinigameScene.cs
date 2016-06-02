using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the data on the scene that appears after a minigame
/// </summary>
public class EndMinigameScene : MonoBehaviour {
    //Card box of the NPC
    public Image npcCardBox;
    //Name box of the NPC
    public Text npcNameBox;
    //Sprite of the NPC
    public Image npcSprite;
    //Time length that the screen should be active
    public float screenDuration;
    //Time that the screen is active
    private float timeActive;

    //Scene that appears after the minigame, the one that appears after this screen
    public GameObject endGameScene;

	// Use this for initialization
	void Start () {
        if(DataTracking.currentNPC != null)
        {
            npcNameBox.text = DataTracking.currentNPC.FirstName + " " + DataTracking.currentNPC.LastName;
            npcSprite.sprite = DataTracking.currentNPC.CharacterSprite[0];
        }
        else
        {
            npcNameBox.text = DataTracking.currentNPC.FullName;
            npcSprite.sprite = DataTracking.currentNPC.CharacterSprite[0];
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive > screenDuration)
            {
                endGameScene.GetComponent<EndGameScene>().ActivateScreen();
            }
        }
	}

    /// <summary>
    /// Activates the end screen after minigame
    /// </summary>
    public void ActivateScreen()
    {
        gameObject.SetActive(true);
    }
}
