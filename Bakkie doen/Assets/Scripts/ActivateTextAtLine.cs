using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

	private List<string> theScript = new List<string>();

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;
    public NPCController npc;
    public bool isShoutZone;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
		//theScript = DialogueClass.Instance.GetDialogueForNPC (gameObject.name).ToList();
		var h = DialogueClass.Instance.GetDialogueForNPC (gameObject.name); 
		foreach (var item in h) {
			theScript.Add (item);
		}
    }
	
	// Update is called once per frame
	void Update () {
        //print("Empty---------------------------------");
        if (waitForPress && Input.GetKeyDown(KeyCode.T))
        {
            //theTextBox.ReloadScript(theText);
            //theTextBox.currentLine = startLine;
            //theTextBox.endAtLine = endLine;
            //theTextBox.stopPlayerMovement = true;
            //if (gameObject.GetComponent<NPCController>() != null)
            //{
            //    gameObject.GetComponent<NPCController>().dialogueFinished = true;
            //}
            //theTextBox.EnableTextBox();

			theTextBox.ReloadScript(theScript.ToArray());
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.stopPlayerMovement = true;
            //if (gameObject.GetComponent<NPCController>() != null)
            //{
            //    gameObject.GetComponent<NPCController>().dialogueFinished = true;
            //}
            theTextBox.EnableTextBox();


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

            if (npc != null && isShoutZone)
            {
                //theTextBox.ReloadScript(theScript.ToArray());
                //theTextBox.currentLine = startLine;
                //theTextBox.endAtLine = endLine;
                //theTextBox.EnableTextBox();
                theTextBox.ReloadScript(DialogueClass.Instance.GetDialogueForNPC(npc.name));
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
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
