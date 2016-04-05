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
	public static Dictionary<string, string[]> npcDialogues = new Dictionary<string,string[]>();
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
        // Else (maybe)
		throw new KeyNotFoundException ("Couldn't find " + npcName);
    }

    public void AddNPCDialogue(string key, string[] value)
    {
		DialogueClass.npcDialogues.Add(key, value);
    }
}
