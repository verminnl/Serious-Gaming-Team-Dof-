using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActivateTextAtLine : MonoBehaviour {

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

	private List<string> theScript = new List<string>();

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;
    public bool isNarratorTrigger;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
		//theScript = DialogueClass.Instance.GetDialogueForNPC (gameObject.name).ToList();
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
        if (waitForPress && Input.GetKeyDown(KeyCode.T))
        {
			theTextBox.ReloadScript(theScript.ToArray());
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.stopPlayerMovement = true;
            if (gameObject.GetComponent<NPCController>() != null)
            {
                theTextBox.currentNPC = gameObject.GetComponent<NPCController>();
            }
            theTextBox.EnableTextBox();
            theTextBox.isNPCDialogue = true;


            //var test = new System.Collections.Generic.Dictionary<NPCCLASS, System.Collections.Generic.List<string>>();

            //var listwithdialog = test[REDNPC];

            //loop door die lijst heen enzo

            //if(WELKE REGEL VAN DE LIST<STRING> IS NET VOORGELEZEN == HET EIND VAN DE LIST)
            //CLOSE DIALOG LOAD NEW LEVEL

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	}

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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            theTextBox.DisableTextBox();
            waitForPress = false;
        }
    }
}
