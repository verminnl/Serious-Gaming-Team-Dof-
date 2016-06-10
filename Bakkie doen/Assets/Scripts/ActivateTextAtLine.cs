using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
    //Controller of the game
    private GameController gc;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
        gc = FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        //When player is in the trigger and presses on the {Enter key or keypadenter}, activate the dialogue and stops player movement
        if (waitForPress)
        {
            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            {
			    theTextBox.ReloadScript(theScript.ToArray());
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.stopPlayerMovement = true;
                if (gameObject.GetComponent<NPC>() != null)
                {
                    theTextBox.currentNPC = gameObject.GetComponent<NPC>().avatar;
                    DataTracking.currentNPC = gameObject.GetComponent<NPC>().avatar;
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
	}

    /// <summary>
    /// Activates when this gameobject collides with another gameobject
    /// </summary>
    /// <param name="other">The gameobject that this gameobject collides with</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
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
            theTextBox.DisableTextBox();
            waitForPress = false;
        }
    }
}
