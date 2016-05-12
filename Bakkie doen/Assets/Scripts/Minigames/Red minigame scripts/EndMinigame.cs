﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Ends the minigame when the player touches the gameobject that has this script attached to it
/// </summary>
public class EndMinigame : MonoBehaviour {
    //The player of the minigame
    public RedMinigamePlayerController thePlayer;
    //Time that the minigame will take in seconds
    public int gameTime;
    //Screen that appears when the minigame ends
    public GameObject minigameEndScreen;
    //Screen that appears before the game ends
    public GameObject gameEndScreen;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, thePlayer.transform.position.y + thePlayer.moveSpeed * gameTime, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    /// <summary>
    /// *TO BE CHANGED*
    /// When the player collides with this gameobject, closes the game
    /// </summary>
    /// <param name="other">The gameobject that collides with this one</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            minigameEndScreen.GetComponent<EndMinigameScene>().ActivateScreen();
        }
    }
}
