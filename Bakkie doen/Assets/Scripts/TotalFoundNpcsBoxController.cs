using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Shows the number of found NPCs on the UI of the player
/// </summary>
public class TotalFoundNpcsBoxController : MonoBehaviour {
    //Textbox where the number of found NPCs will be displayed
    public Text textbox;

	// Use this for initialization
	void Start () {
        textbox.text = "Gevonden collega's: " + DataTracking.playerData.FoundPlayers.intList.Length + "/" + DataTracking.npcData.Count;
	}
}
