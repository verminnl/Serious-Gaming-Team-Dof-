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
    //Decides if the player should flash or not
    private bool flashActive;
    //How long the player will flash
    public float flashLenght;
    //Counts how long the player has been flashing
    private float flashCounter;
    //Sprite Renderer of the player
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        ActivateFlash();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            flashActive = true;
            flashCounter = flashLenght;
            Debug.Log(flashActive);
        }
    }

    void ActivateFlash()
    {
        if (flashActive)
        {
            if (flashCounter > flashLenght * .66f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
            }
            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }
}
