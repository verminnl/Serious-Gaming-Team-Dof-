using UnityEngine;
using System.Collections;

/// <summary>
/// Ends the minigame when the player touches the gameobject that has this script attached to it
/// </summary>
public class BlueMinigameEndMinigame : MonoBehaviour {
    //The player of the minigame
    public BlueMinigamePlayerController thePlayer;
    //Screen that appears when the minigame ends
    public GameObject minigameEndScreen;
    //Screen that appears before the game ends
    public GameObject gameEndScreen;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    /// <summary>
    /// When the player collides with this gameobject, closes the game, destroys the current player
    /// </summary>
    /// <param name="other">The gameobject that collides with this one</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            minigameEndScreen.GetComponent<EndMinigameScene>().ActivateScreen();
            Destroy(thePlayer.gameObject);
        }
    }
}
