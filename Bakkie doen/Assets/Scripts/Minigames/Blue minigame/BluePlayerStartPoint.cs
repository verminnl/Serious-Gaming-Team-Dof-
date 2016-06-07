using UnityEngine;

/// <summary>
/// Manages the startpoint for the player
/// </summary>
public class BluePlayerStartPoint : MonoBehaviour {
    //Player in the blue minigame
    private BlueMinigamePlayerController thePlayer;
    //Name for the startpoint
    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<BlueMinigamePlayerController>();
        //Sets the position of the player to the position of the startpoint
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
        }
	}
}
