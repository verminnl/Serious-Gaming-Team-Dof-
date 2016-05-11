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
    //Animation of the player
    private Animator playerAnim;
    //Change in the x-position of the player
    private float playerXChange;
    //Change in the y-position of the player
    private float playerYChange;
    //Gets the last movement of the player
    public Vector2 lastMove;
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

        playerAnim = thePlayer.GetComponent<Animator>();
        
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
                    //Activates a dialogue, if there are dialogues added to the waypoint
                    //Else, gets the next waypoint for the player to navigate to
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
                    //Sets the walking animation for the player when he/she is moving around the tutorial
                    playerAnim.SetBool("PlayerMoving", false);

                    //Moving right
                    if (waypoints[currentIndexWaypoint].transform.position.x - thePlayer.transform.position.x > 0.5f)
                    {
                        playerAnim.SetBool("PlayerMoving", true);
                        playerXChange = 1f;
                        lastMove = new Vector2(playerXChange, 0f);
                    }
                    //Moving left
                    if (waypoints[currentIndexWaypoint].transform.position.x - thePlayer.transform.position.x < -0.5f)
                    {
                        playerAnim.SetBool("PlayerMoving", true);
                        playerXChange = -1f;
                        lastMove = new Vector2(playerXChange, 0f);
                    }
                    //Moving up
                    if (waypoints[currentIndexWaypoint].transform.position.y - thePlayer.transform.position.y > 0.5f)
                    {
                        playerAnim.SetBool("PlayerMoving", true);
                        playerYChange = 1f;
                        lastMove = new Vector2(0f, playerYChange);
                    }
                    //Moving down
                    if (waypoints[currentIndexWaypoint].transform.position.y - thePlayer.transform.position.y < -0.5f)
                    {
                        playerAnim.SetBool("PlayerMoving", true);
                        playerYChange = -1f;
                        lastMove = new Vector2(0f, playerYChange);
                    }

                    playerAnim.SetFloat("MoveX", playerXChange);
                    playerAnim.SetFloat("MoveY", playerYChange);
                    playerAnim.SetFloat("LastMoveX", lastMove.x);
                    playerAnim.SetFloat("LastMoveY", lastMove.y);

                    //Moves the player to the next waypoint
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
