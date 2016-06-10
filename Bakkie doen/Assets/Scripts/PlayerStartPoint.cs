using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Sets the starting position of the player
/// </summary>
public class PlayerStartPoint : MonoBehaviour {
    //Player of the game
    private PlayerController thePlayer;
    //Camera of the game
    private CameraController theCamera;
    //Direction that the player is facing when spawned
    public Vector2 startDirection;
    //Name of teh spawnpoint
    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        setPlayerStartPoint();

        //Sets the position of the player to the given spawnpoint
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}

    /// <summary>
    /// Decides the start point for the player depending on the current active scene
    /// </summary>
    public void setPlayerStartPoint()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != DataTracking.previousFloor)
        {
            switch (DataTracking.previousFloor)
            {
                case "T0":
                    thePlayer.startPoint = (currentScene == "T1" ? "T1_Down" : "T3_Up");
                    break;
                case "T1":
                    thePlayer.startPoint = (currentScene == "T2" ? "T2_Down" : "T0_Up");
                    break;
                case "T2":
                    thePlayer.startPoint = (currentScene == "T3" ? "T3_Down" : "T1_Up");
                    break;
                case "T3":
                    thePlayer.startPoint = (currentScene == "T0" ? "T0_Down" : "T2_Up");
                    break;
                case "Elevator_Red":
                case "Elevator_Blue":
                case "Elevator_Yellow":
                case "Elevator_Green":
                    thePlayer.startPoint = DataTracking.previousFloor;
                    break;
            }
        }
    }
}
