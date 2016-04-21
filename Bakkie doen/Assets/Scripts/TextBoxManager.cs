using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    private PlayerController player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public bool isNPCDialogue = false;
    public float typeSpeed;

    public NPCController currentNPC;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (endAtLine == 0)
        {
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

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                currentLine += 1;

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
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
	}

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

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
    }

    public void ReloadScript(string[] npcScript)
    {
        if (npcScript != null)
        {
            textLines = new string[1];
            textLines = npcScript;
        }
    }
}
