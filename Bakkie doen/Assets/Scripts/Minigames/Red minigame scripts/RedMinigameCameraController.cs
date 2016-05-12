using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the camera in the red minigame
/// </summary>
public class RedMinigameCameraController : MonoBehaviour {
    //Gameobject that the camera will follow
    public GameObject followTarget;
    //Movement speed of the camera when it is following a gameobject
    public float moveSpeed;
    //Position of the gameobject that the camera is following
    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //If there is a gameobject that the camera should follow, camera will move to the position of the gameobject
        if (followTarget != null)
        {
            targetPos = new Vector3(transform.position.x, followTarget.transform.position.y + 8, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
	}
}
