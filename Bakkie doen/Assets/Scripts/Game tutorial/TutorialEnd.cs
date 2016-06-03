using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the end of the tutorial
/// </summary>
public class TutorialEnd : MonoBehaviour {
    //Box with the background image for the end screen
    public Image backgroundImage;
    //Textbox for the end screen
    public Text theText;

	// Use this for initialization
	void Start () {
        theText.text = theText.text + DataTracking.playerData.FirstName + "!";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            BackEndCommunicator.Instance.EndGameSave(DataTracking.playerData.PlayerID, 0, DataTracking.playerData.SessionID, "", false);
            DataTracking.resetGame();
        }
	}
}