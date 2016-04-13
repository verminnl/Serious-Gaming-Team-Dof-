using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the player in the red minigame
/// </summary>
public class RedMinigamePlayerController : MonoBehaviour {
    //Movement speed of the player
    public float moveSpeed;
    //The gameobject that has this script will be affected by gravity and can be controlled from using forces
    private Rigidbody2D myRigidBody;
    //Decides if the player can move or not
    public bool canMove;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //If the player is not able to walk, exit function
        if (!canMove)
        {
            return;
        }

        //When there is an input change in the Horizontal axis, move the player in that direction based on
        //the given movement speed while continuously moving upwards
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, moveSpeed);
        }
        //When there is an input change in bot of the direction of the Horizontal axis, the player will not
        //move in either direction while continuously moving upwards
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(0f, moveSpeed);
        }
	}
}
