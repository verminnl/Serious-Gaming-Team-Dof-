using System.Collections.Generic;

/// <summary>
/// Class for each NPC with their own data
/// </summary>
public class NPCClass {
    //Counts the number of NPCs that has been created in the game
    public static int number;
    //Name of the NPC
    public string name;
    //Color type of the NPC
    public string type;
    //List with all the skills that the NPC has
    public List<string> skills;

    public NPCClass(string name, string type, string[] dialogue, List<string> skills)
    {
        //Adds the newly created NPC in the Dictionary in the DialogueClass with its dialogue
        //if it doesn't exist yet
        if (DialogueClass.npcDialogues.ContainsKey(name))
        {
            return;
        }
        else
        {
            this.name = name;
            this.type = type;
            this.skills = skills;
            DialogueClass.Instance.AddNPCDialogue(name, dialogue);
            number++;
        }
    }
}