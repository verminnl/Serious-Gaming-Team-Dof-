using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCClass {
    public static int number;
    public string name;
    public string type;
    public List<string> skills;

    public NPCClass(string name, string type)
    {
        this.name = name;
        this.type = type;
        number++;
    }

    public void getDialogue()
    {

    }
}
