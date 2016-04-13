using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;
    public bool inMinigame;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists && !inMinigame)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!inMinigame)
        {
            if (!canMove)
            {
                return;
            }

            playerMoving = false;

            if (!attacking)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }

                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
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

                if (Input.GetKeyDown(KeyCode.J))
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    myRigidBody.velocity = Vector2.zero;
                    anim.SetBool("Attack", true);
                }
            }

            if (attackTimeCounter > 0)
            {
                attackTimeCounter -= Time.deltaTime;
            }

            if (attackTimeCounter <= 0)
            {
                attacking = false;
                anim.SetBool("Attack", false);
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
        else
        {
            Destroy(gameObject);
        }

	}
}
