using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Manages the behaviour of the textbox
/// </summary>
public class TextBoxManager : MonoBehaviour {
    //Textbox that will display dialogues
    public GameObject textBox;
    //The text that will be displayed when textbox is active
    public Text theText;
    //The lines that are going to be displayed when textbox is active
    public string[] textLines;
    //The current line that is being displayed
    public int currentLine;
    //The line that the dialogue should end
    public int endAtLine;
    //Player of the game
    private PlayerController player;
    //Checks if the textbox is active
    public bool isActive;
    //Checks if the movement of the player should be stopped
    public bool stopPlayerMovement;
    //Checks if a line is being typed in the textbox
    private bool isTyping = false;
    //Checks if the typing of a line should be cancelled
    private bool cancelTyping = false;
    //Checks if the dialogue is from an NPC
    public bool isNPCDialogue = false;
    //Type speed
    public float typeSpeed;
    //NPC that the player is talking to
    public NPCController currentNPC;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (endAtLine == 0)
        {
            //Sets the end of the dialogue
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActive)
        {
            return;
        }

        //Displayes lines of the dialogue when pressed on the Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTyping)
            {
                //Goes to the next line when lines aren't being typed into the textbox
                currentLine += 1;

                //Disables the textbox
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                    
                    if (isNPCDialogue && currentNPC != null)
                    {
                        currentNPC.dialogueFinished = true;
                    }

                }
                else
                {
                    //Starts typing the lines into the textbox
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
	}

    /// <summary>
    /// Prints the lines of a dialogue letter by letter
    /// </summary>
    /// <param name="lineOfText">The line that will be printed into the textbox</param>
    /// <returns>Time that game should wait before printing the next letter</returns>
    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping == true && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    /// <summary>
    /// Enables the textbox and starts printing lines into it, also stops the player from moving
    /// </summary>
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    /// <summary>
    /// Disables the textbox and lets the player start moving
    /// </summary>
    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
    }

    /// <summary>
    /// Gets the lines that the NPC should say
    /// </summary>
    /// <param name="npcScript">Script with the lines that the NPC should say</param>
    public void ReloadScript(string[] npcScript)
    {
        if (npcScript != null)
        {
            textLines = new string[1];
            textLines = npcScript;
        }
    }
}
