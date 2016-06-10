using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the behaviour and the details of an NPC
/// </summary>
public class NPC : MonoBehaviour {
    //Data of this NPC
    public AvatarData avatar;
    //Dialogue box in the game
    public GameObject textBox;
    //Player in the game
    public PlayerController player;
    //Checks if the dialogue box is active
    public bool textBoxActive;
    //Textbox for the dialogue
    public Text textBoxText;
    //Current line of the dialogue
    private int lineCounter;
    //Game controller of the game
    public GameController gameController;
    //Check if the player is in the triggerbox of this NPC
    private bool playerInTriggerBox;
   
    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Activates the dialogue if the player is near this NPC and he presses on the {Enter key or keypadenter}
        if (playerInTriggerBox)
        {
            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            {
                ActivateDialogue();
            }
        }
        //Goes through the dialogue when the dialogue box is active and when the player presses on the {Enter key or keypadenter}
        if (textBoxActive)
        {
            if(lineCounter == 0)
            {
                textBoxText.text = DataTracking.currentNPC.Dialogue[lineCounter];
            }
            if (lineCounter < 3)
            {
                if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
                {
                    textBoxText.text = DataTracking.currentNPC.Dialogue[lineCounter];
                    lineCounter++;
                }
                
            }
            else if(lineCounter == 3)
            {
                if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
                {
                    gameController.dialogueFinished = true;
                }
            }
        }
    }

    /// <summary>
    /// Activates when this gameobject collides with another gameobject
    /// </summary>
    /// <param name="other">The gameobject that this gameobject collides with</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTriggerBox = true;
        }
    }

    /// <summary>
    /// Activates when this gameobject stops colliding with another gameobject
    /// </summary>
    /// <param name="other">The gameobject that this gameobject was colliding with</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTriggerBox = false;
        }
    }

    /// <summary>
    /// Activates the dialogue box
    /// </summary>
    void ActivateDialogue()
    {
        textBox.SetActive(true);
        textBoxActive = true;
        player.canMove = false;
        DataTracking.currentNPC = avatar;
    }
}