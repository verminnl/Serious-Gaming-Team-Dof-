using UnityEngine;

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
    //Type of bullet
    public ObjectPooler bulletType;
    //Health of the player
    private HealthManager health;
    //Checks if the player is alive
    public static bool isAlive;
    //Screen that appears when the player is dead
    public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = FindObjectOfType<HealthManager>();
        isAlive = true;
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
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * -1, moveSpeed);
        }
        //When there is an input change in bot of the direction of the Horizontal axis, the player will not
        //move in either direction while continuously moving upwards
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(0f, moveSpeed);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            //Gets the map that will be generated
            GameObject newBullet = bulletType.GetPooledObject();

            //Sets the position of the map to be equal to the generationpoint
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;

            //Sets the state of the map to active
            newBullet.SetActive(true);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletType.moveSpeed);
        }

        //Makes the player flash if {flashActive} is true
        if (flashActive)
        {
            ActivateFlash();
        }
	}

    /// <summary>
    /// Activates when this gameobject touches another object with a triggerbox
    /// </summary>
    /// <param name="other">The object that this gameobject touches</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            flashActive = true;
            flashCounter = flashLenght;
            Destroy(other.gameObject.GetComponent<Collider2D>());
            health.TakeDamage();
        }
    }

    /// <summary>
    /// Makes the player sprite flash for {flashLength} seconds
    /// </summary>
    void ActivateFlash()
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
