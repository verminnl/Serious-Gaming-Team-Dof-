using UnityEngine;

/// <summary>
/// Controls the player in the blue minigame
/// </summary>
public class BlueMinigamePlayerController : MonoBehaviour {
    //Movement speed of the player
    public float moveSpeed;
    //Rigidbody2D component of the player
    private Rigidbody2D myRigidBody;
    //Name of the startpoint that the player will be spawned at
    public string startPoint;

    
	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Controls the walking cycle of the player
        //Player movement horizontally
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
        }
        //Player movement vertically
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        //Player idle horizontally
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }
        //Player idle vertically
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }
    }
}