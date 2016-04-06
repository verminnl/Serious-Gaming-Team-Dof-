using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Dialogue database Singleton
/// </summary>
public class DialogueClass
{

	/// <summary>
	/// THIS PROPERTY CAN ONLY BE CALLED FROM THE DIALOGUECLASS CLASS
	/// </summary>
    public static Dictionary<string, string[]> npcDialogues = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> narratorDialogues = new Dictionary<string, string[]>();
	private static DialogueClass instance = null;
	public static DialogueClass Instance {
		get {
			if (instance == null) {
				instance = new DialogueClass ();
			}

			return instance;
		}
	}

    public string[] GetDialogueForNPC(string npcName)
    {
		if (DialogueClass.npcDialogues.ContainsKey (npcName)) {
			return npcDialogues [npcName];
		}
		throw new KeyNotFoundException ("Couldn't find dialogues for " + npcName);
    }

    public void AddNPCDialogue(string key, string[] value)
    {
		DialogueClass.npcDialogues.Add(key, value);
    }

    public string[] GetNarratorDialogue(string npcName)
    {
        if (DialogueClass.narratorDialogues.ContainsKey(npcName))
        {
            return narratorDialogues[npcName];
        }
        throw new KeyNotFoundException("Couldn't find narrator dialogues for " + npcName);
    }

    public void AddNarratorDialogue(string key, string[] value)
    {
        DialogueClass.narratorDialogues.Add(key, value);
    }
}
