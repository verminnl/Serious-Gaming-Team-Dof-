using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueClass
{
    public Dictionary<string, string[]> npcDialogues = new Dictionary<string,string[]>();

    public DialogueClass(string key, string[] value)
    {
        npcDialogues.Add(key, value);
    }

    public void ToString(string name)
    {
        //System.Console.WriteLine();
        //Debug.Log(npcDialogues[name][5]);
    }
}
