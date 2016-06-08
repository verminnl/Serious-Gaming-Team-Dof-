using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public AvatarData avatar;
    public GameObject textBox;
    public PlayerController player;
    public bool textBoxActive;
    public Text textBoxText;

    private int lineCounter;
    public GameController gameController;
    private bool playerInTriggerBox;
   
    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInTriggerBox)
        {
            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            {
                ActivateDialogue();
            }
        }
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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTriggerBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTriggerBox = false;
        }
    }

    void ActivateDialogue()
    {
        textBox.SetActive(true);
        textBoxActive = true;
        player.canMove = false;
        DataTracking.currentNPC = avatar;
    }
}