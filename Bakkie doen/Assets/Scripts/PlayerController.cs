using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string playerName;

    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;

    public string startPoint;

    public bool canMove;
    public bool inMinigame;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().sprite = DataTracking.playerData.CharacterSprite[0];
        myRigidBody = GetComponent<Rigidbody2D>();
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
            if (!canMove)
            {
                myRigidBody.velocity = Vector2.zero;
                return;
            }

            playerMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * -1, myRigidBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal") * -1);
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x * -1);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
	}
}