using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Controls the NPCs in the game
/// </summary>
public class NPCController : MonoBehaviour {
    //Color type of the NPC
    public string colorType;
    //Dialogue lines of the NPC
    public string[] dialogue;
    //Checks if the NPC is done with its dialogue
    public bool dialogueFinished;
    //List with all the skills given by its player
    public List<string> NPCSkills;
    //Current NPC
    public NPCClass npc;
    //Name of current NPC
    public string nameNPC;
    //Room of the NPC
    public string roomNumber;
    //Sprite of current NPC
    public Sprite sprite;
    //Camera in the game
    private CameraController theCamera;
    //Player in the game
    private PlayerController thePlayer;
    //Game controller of the game
    private GameController theGame;

    //Triggered before the initialization
    void Awake()
    {
        theCamera = FindObjectOfType<CameraController>();
        thePlayer = FindObjectOfType<PlayerController>();
        theGame = FindObjectOfType<GameController>();
        nameNPC = gameObject.name;
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        //Creates an NPC with the given details
        npc = new NPCClass(nameNPC, colorType, dialogue, NPCSkills);
        if (theGame != null)
        {
            theGame.AddNPCToList(this);
        }
    }

	// Use this for initialization
	void Start () {
        //print("NPC name: " + npc.name + ", NPC type: " + npc.type + ", Number of NPCs: " + NPCClass.number);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
