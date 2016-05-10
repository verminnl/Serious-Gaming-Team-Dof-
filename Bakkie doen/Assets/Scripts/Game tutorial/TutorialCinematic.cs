using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialCinematic : MonoBehaviour {
    //List with all the waypoints in the game
    private List<GameObject> waypoints = new List<GameObject>();
    //Current index of waypoint
    private int currentIndexWaypoint;
    //Current waypoint
    private GameObject currentWaypoint;
    //Player in the tutorial
    public GameObject thePlayer;
    //Check if the tutorial is done
    private bool done;
    //Speed of the tutorial
    public float tutorialSpeed;
    //Distance to detect the next waypoint
    public float distanceDetection;
    //Textbox manager in the tutorial
    public TextBoxManager tbManager;

	// Use this for initialization
	void Start () {
        currentIndexWaypoint = 0;

        //Gets the waypoints for the tutorial and makes sure that it doesn't have a sprite attached to it
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(gameObject.transform.GetChild(i).gameObject);
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>() != null)
            {
                Destroy (gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
            }
        }

        //Sets the position of the player to the first waypoint
        thePlayer.transform.position = waypoints[currentIndexWaypoint].transform.position;
        //Gets the second waypoint
        currentWaypoint = GetNextWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (!done)
        {
            //Makes sure that the player cannot move during the whole tutorial
            thePlayer.GetComponent<PlayerController>().canMove = false;

            //Moves the player to the next waypoint if there are still waypoints in the game
            //Ends the tutorial if there aren't anymore waypoints
            if (currentWaypoint != null)
            {
                if (Vector3.Distance(thePlayer.transform.position, currentWaypoint.transform.position) < distanceDetection)
                {
                    if (currentWaypoint.GetComponent<WaypointDialogue>() != null)
                    {
                        if (currentWaypoint.GetComponent<WaypointDialogue>().dialogueStarted == false)
                        {
                            tbManager.ReloadScript(currentWaypoint.GetComponent<WaypointDialogue>().lines);
                            tbManager.endAtLine = currentWaypoint.GetComponent<WaypointDialogue>().lines.Length - 1;
                            tbManager.EnableTextBox();
                            currentWaypoint.GetComponent<WaypointDialogue>().dialogueStarted = true;
                            if (tbManager.currentLine > currentWaypoint.GetComponent<WaypointDialogue>().lines.Length - 1)
                            {
                                tbManager.DisableTextBox();
                            }
                        }
                        if (tbManager.isActive == false)
                        {
                            tbManager.currentLine = 0;
                            Debug.Log(tbManager.currentLine);
                            currentWaypoint = GetNextWaypoint();
                        }
                    }
                    else
                    {
                        currentWaypoint = GetNextWaypoint();
                    }
                }
                else
                {
                    thePlayer.transform.position = Vector3.MoveTowards(thePlayer.transform.position, waypoints[currentIndexWaypoint].transform.position, Time.deltaTime * tutorialSpeed);
                }
            }
            else
            {
                done = true;
            }
        }
        
	}

    /// <summary>
    /// Gets the next waypoint for the player to move to
    /// </summary>
    /// <returns>The next waypoint, or null if there aren't anymore waypoints</returns>
    private GameObject GetNextWaypoint()
    {
        if (currentIndexWaypoint != waypoints.Count - 1)
        {
            GameObject nextWaypoint = waypoints[currentIndexWaypoint + 1];
            currentIndexWaypoint++;
            return nextWaypoint;
        }
        else
        {
            return null;
        }
    }
}
