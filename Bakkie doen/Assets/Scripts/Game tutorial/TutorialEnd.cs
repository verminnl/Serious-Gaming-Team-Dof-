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
    //Name of the player
    public string namePlayer;
    //Time that the screen will be active
    public float activeTime;
    //Time that the screen is active
    private float timer;

	// Use this for initialization
	void Start () {
        theText.text = theText.text + DataTracking.playerData.FirstName + "!";
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;

        Debug.Log(timer);

        if (timer > activeTime)
        {
            BackEndCommunicator.Instance.EndGameSave(DataTracking.playerData.PlayerID, 0, DataTracking.playerData.SessionID, "", false);
            DataTracking.resetGame();
        }
	}
}
