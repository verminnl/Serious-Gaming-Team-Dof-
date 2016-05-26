using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController thePlayer;
    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        setPlayerStartPoint();
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
            }
        }
    }
}
