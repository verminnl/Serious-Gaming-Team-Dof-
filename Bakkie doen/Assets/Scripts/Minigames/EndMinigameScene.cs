using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    //Check if the screen is active
    private bool isActive;
    //Scene that appears after the minigame, the one that appears after this screen
    public GameObject endGameScene;

	// Use this for initialization
	void Start () {
        npcNameBox.text = DataTracking.theNPC.name;
        npcSprite.sprite = DataTracking.theNPC.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
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
        isActive = true;
    }
}
