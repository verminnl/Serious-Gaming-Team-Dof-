using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public AvatarData avatar;
    public bool dialogueFinished;
    public GameObject textBox;
    public PlayerController player;
    public bool textBoxActive;
    public Text textBoxText;

    private int lineCounter;
   
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (textBoxActive)
        {
            if(lineCounter == 0)
            {
                textBoxText.text = DataTracking.currentNPC.avatar.Dialogue[lineCounter];
            }
            if (Input.GetKeyUp(KeyCode.Space) && lineCounter < 3)
            {
                textBoxText.text = DataTracking.currentNPC.avatar.Dialogue[lineCounter];
                lineCounter++;
            }
            else if(lineCounter == 3 && Input.GetKeyUp(KeyCode.Space))
            {
                dialogueFinished = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyUp(KeyCode.Space) && !textBoxActive)
        {
            textBox.SetActive(true);
            textBoxActive = true;
            player.canMove = false;
            DataTracking.currentNPC = this;
        }
    }
}