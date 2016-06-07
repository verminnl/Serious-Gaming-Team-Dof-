using UnityEngine;

/// <summary>
/// Ends the minigame when the player touches the gameobject that has this script attached to it in the Red Minigame
/// </summary>
public class EndMinigame : MonoBehaviour {
    //The player of the minigame
    public RedMinigamePlayerController thePlayer;
    //Time that the minigame will take in seconds
    public int timeLimit;
    //Screen that appears when the minigame ends
    public GameObject gameEndScreen;
    //Screen that appears when the player is dead
    public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
        //Sets the position of the gameobject based on the player speed and the time that the minigame should last
        transform.position = new Vector3(transform.position.x, thePlayer.transform.position.y + thePlayer.moveSpeed * timeLimit, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        //Destroys the player when the minigame ends
        if (!RedMinigamePlayerController.isAlive && thePlayer != null)
        {
            gameOverScreen.GetComponent<GameOver>().ActivateScreen();
            Destroy(thePlayer.gameObject);
        }
	}

    /// <summary>
    /// When the player collides with this gameobject, activates the end game scene and destroys the current player
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
