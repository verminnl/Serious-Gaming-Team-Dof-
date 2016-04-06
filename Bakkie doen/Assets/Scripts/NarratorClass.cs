using UnityEngine;
using System.Collections;

public class NarratorClass {

    public string nameTrigger;
    
    public NarratorClass(string name, string[] dialogue)
    {
        if (DialogueClass.narratorDialogues.ContainsKey(name))
        {
            return;
        }
        else
        {
            this.nameTrigger = name;
            DialogueClass.Instance.AddNarratorDialogue(this.nameTrigger, dialogue);
        }
    }

}
