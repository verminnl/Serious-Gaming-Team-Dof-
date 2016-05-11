using UnityEngine;
using System.Collections;

/// <summary>
/// Dialogue for when the player reaches a certain waypoint
/// </summary>
public class WaypointDialogue : MonoBehaviour {
    //List with the lines for the waypoint
    public string[] lines;
    //Checks if the dialogue has been started
    public bool dialogueStarted = false;
    //Player
    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i].Contains("#playername"))
            {
                Debug.Log("There is #playername");
                lines[i] = lines[i].Replace("#playername", thePlayer.playerName);
            }
            else
            {
                Debug.Log("No #playername");
            }
        }
	}
}
