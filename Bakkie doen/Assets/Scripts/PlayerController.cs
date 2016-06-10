using UnityEngine;

/// <summary>
/// Controls the behaviour of the player
/// </summary>
public class PlayerController : MonoBehaviour {
    //Movement speed of the player
    public float moveSpeed;
    //Animator component of the player
    private Animator anim;
    //Rigidbody2D component of the player
    private Rigidbody2D myRigidBody;
    //Checks if the player is moving
    private bool playerMoving;
    //Registers the last direction that the player has been moving to
    public Vector2 lastMove;
    //Checks if the player exists
    private static bool playerExists;
    //Name of the starting point of the player
    public string startPoint;
    //Decides if the player is allowed to move or not
    public bool canMove;
    //Checks if the player is in a minigame
    public bool inMinigame;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().sprite = DataTracking.playerData.CharacterSprite[0];
        myRigidBody = GetComponent<Rigidbody2D>();

        //Spawns the player on a given position
        if(DataTracking.playerData.SpawnPoint != "")
        {
            string[] spawnSplit = DataTracking.playerData.SpawnPoint.Split('_');
            float posX, posY;
            float.TryParse(spawnSplit[1], out posX);
            float.TryParse(spawnSplit[2], out posY);
            transform.position = new Vector3(posX, posY, transform.position.z);
            DataTracking.playerData.SpawnPoint = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!inMinigame)
        {
            //Sets the velocity of the player to 0 if the player is not allowed to move
            if (!canMove)
            {
                myRigidBody.velocity = Vector2.zero;
                return;
            }

            playerMoving = false;

            //Controls the movement of the player
            //Moving horizontally
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * -1, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            //Moving vertically
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            //Idling horizontally
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
            }
            //Idling vertically
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
            }

            //Controls the animation of the player
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal") * -1);
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x * -1);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
	}
}