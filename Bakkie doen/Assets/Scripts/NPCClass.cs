using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCClass {
    public static int number;
    public string name;
    public string type;
    public List<string> skills;

    public NPCClass(string name, string type, string[] dialogue)
    {
        if (DialogueClass.npcDialogues.ContainsKey(name))
        {
            return;
        }
        else
        {
            this.name = name;
            this.type = type;
            DialogueClass.Instance.AddNPCDialogue(name, dialogue);
            number++;
        }
    }
}
