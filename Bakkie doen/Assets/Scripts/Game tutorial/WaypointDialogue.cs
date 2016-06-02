using UnityEngine;

/// <summary>
/// Dialogue for when the player reaches a certain waypoint
/// </summary>
public class WaypointDialogue : MonoBehaviour {
    //List with the lines for the waypoint
    public string[] lines;
    //Checks if the dialogue has been started
    public bool dialogueStarted = false;
    //Check if dialogue playername has been trimmed
    public bool dialogueTrimmed = false;
    //Screen that will be activated after dialogue
    public GameObject screen;

	// Use this for initialization
	void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (!dialogueTrimmed)
        {
            dialogueTrimmed = true;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (lines[i].Contains("#playername"))
                {
                    if (DataTracking.playerData != null)
                    {
                        lines[i] = lines[i].Replace("#playername", DataTracking.playerData.FirstName);
                    }
                    else
                    {
                        lines[i] = lines[i].Replace("#playername", "Gast");
                    }
                }
            }
        }
	}
}
