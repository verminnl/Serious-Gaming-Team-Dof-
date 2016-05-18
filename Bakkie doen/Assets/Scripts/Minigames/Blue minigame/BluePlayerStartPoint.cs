using UnityEngine;
using System.Collections;

public class BluePlayerStartPoint : MonoBehaviour {

    private BlueMinigamePlayerController thePlayer;
    private BlueMinigameCameraController theCamera;

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<BlueMinigamePlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<BlueMinigameCameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
