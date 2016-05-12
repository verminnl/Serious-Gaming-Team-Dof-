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

	// Use this for initialization
	void Start () {
        npcNameBox.text = DataTracking.theNPC.name;
        npcSprite.sprite = DataTracking.theNPC.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
