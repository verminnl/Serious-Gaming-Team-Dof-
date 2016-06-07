using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ends the minigame when the player touches the gameobject that has this script attached to it
/// </summary>
public class BlueMinigameEndMinigame : MonoBehaviour {
    //The player of the minigame
    public BlueMinigamePlayerController thePlayer;
    //Time that the minigame will take in seconds
    public int timeLimit;
    //Time that the player has been playing the minigame
    private float playedTime;
    //Screen that appears before the game ends
    public GameObject gameEndScreen;
    //Screen that appears when the player is dead
    public GameObject gameOverScreen;
    //Timer box
    public Text timerBox;
	
	// Update is called once per frame
	void Update () {
        //The countdown of the timer
        playedTime += Time.deltaTime;
        timerBox.text = "Tijd: " + Mathf.Ceil((timeLimit - playedTime));

        //Destroys the player and display the game over scene when the timer
        //is over and the player haven't reached the finish
        if (thePlayer != null && (int)playedTime > timeLimit)
        {
            gameOverScreen.GetComponent<GameOver>().ActivateScreen();
            Destroy(thePlayer.gameObject);
        }
	}

    /// <summary>
    /// When the player collides with this gameobject, ends the minigame and destroys the player
    /// </summary>
    /// <param name="other">The gameobject that collides with this one</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            gameEndScreen.GetComponent<EndGameScene>().ActivateScreen();
            Destroy(thePlayer.gameObject);
        }
    }
}
