using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the data on the scene that appears at the end of the game
/// </summary>
public class EndGameScene : MonoBehaviour {
    //Text box of screen
    public Text textBox;
    //Time length that the screen should be active
    public float screenDuration;
    //Time that the screen is active
    private float timeActive;
    //Check if the screen is active
    private bool isActive;

	// Use this for initialization
	void Start () {
        textBox.text = textBox.text + DataTracking.thePlayer.playerName;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive > screenDuration)
            {
                Application.Quit();
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
