using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Activates a certain line from a dialogue
/// </summary>
public class ActivateTextAtLine : MonoBehaviour {
    //Line where the dialogue will start
    public int startLine;
    //Line where the dialogue will end
    public int endLine;
    //Current textbox manager in the game
    public TextBoxManager theTextBox;
    //List with the lines for the dialogue
	private List<string> theScript = new List<string>();
    //Checks if the dialogue requires button press to activate
    public bool requireButtonPress;
    //Checks if trigger is waiting for a button press
    private bool waitForPress;
    //Checks if the trigger should be destroted when activated
    public bool destroyWhenActivated;
    //Checks if it's the narrator's dialogue
    public bool isNarratorTrigger;
    //Controller of the game
    private GameController gc;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
        gc = FindObjectOfType<GameController>();

        //Gets the dialogue for the current connected gameobject and adds it to theScript
        if (isNarratorTrigger)
        {
            var h = DialogueClass.Instance.GetNarratorDialogue(gameObject.name);
            foreach (var item in h)
            {
                theScript.Add(item);
            }
        }
        else
        {
            var h = DialogueClass.Instance.GetDialogueForNPC(gameObject.name);
            foreach (var item in h)
            {
                theScript.Add(item);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        //When player is in the trigger and presses on the Spacebar, activate the dialogue and stops player movement
        if (waitForPress && Input.GetKeyUp(KeyCode.Space))
        {
			theTextBox.ReloadScript(theScript.ToArray());
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.stopPlayerMovement = true;
            if (gameObject.GetComponent<NPCController>() != null)
            {
                theTextBox.currentNPC = gameObject.GetComponent<NPCController>();
                DataTracking.theNPC = gameObject.GetComponent<NPCController>();
            }
            theTextBox.EnableTextBox();
            theTextBox.isNPCDialogue = true;
            waitForPress = false;

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            if (isNarratorTrigger)
            {
                theTextBox.ReloadScript(DialogueClass.Instance.GetNarratorDialogue(gameObject.name));
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.stopPlayerMovement = true;
                theTextBox.EnableTextBox();
            }


            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            theTextBox.DisableTextBox();
            waitForPress = false;
        }
    }
}
