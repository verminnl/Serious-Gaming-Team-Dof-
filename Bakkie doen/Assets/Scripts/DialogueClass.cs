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
	private static DialogueClass instance = null;
	public static DialogueClass Instance {
		get {
			if (instance == null) {
				instance = new DialogueClass ();
			}

			return instance;
		}
	}

    /// <summary>
    /// Returns the dialogue for the given NPC
    /// </summary>
    /// <param name="npcName">Name of the NPC</param>
    /// <returns>
    /// Returns the dialogue for the NPC if it exists in the Dictionary
    /// If it doesn't exist, sends out an error
    /// </returns>
    public string[] GetDialogueForNPC(string npcName)
    {
		if (DialogueClass.npcDialogues.ContainsKey (npcName)) {
			return npcDialogues [npcName];
		}
		throw new KeyNotFoundException ("Couldn't find dialogues for " + npcName);
    }

    /// <summary>
    /// Adds dialogue(s) for an NPC to the Dictionary
    /// </summary>
    /// <param name="key">Name of the NPC</param>
    /// <param name="value">Dialogues for the NPC</param>
    public void AddNPCDialogue(string key, string[] value)
    {
		DialogueClass.npcDialogues.Add(key, value);
    }

    /// <summary>
    /// Returns the length of dictionary with NPC dialogues
    /// </summary>
    /// <returns>
    /// Returns the length of dictionary
    /// </returns>
    public int GetNPCDictionaryLength()
    {
        return npcDialogues.Count;
    }
}
