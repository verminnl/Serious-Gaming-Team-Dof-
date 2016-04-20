using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    //Current NPC
    public NPCClass npc;
    //Camera in the game
    private CameraController camera;
    //Player in the game
    private PlayerController player;
    //Game controller of the game
    private GameController theGame;

    //Triggered before the initialization
    void Awake()
    {
        camera = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerController>();
        theGame = FindObjectOfType<GameController>();

        //Creates an NPC with the given details
        npc = new NPCClass(gameObject.name, colorType, dialogue);
        theGame.AddNPCToList(npc);
    }

	// Use this for initialization
	void Start () {
        print("NPC name: " + npc.name + ", NPC type: " + npc.type + ", Number of NPCs: " + NPCClass.number);
	}
	
	// Update is called once per frame
	void Update () {
        //Loads a minigame after a dialogue with an NPC based on its color type
        //if (dialogueFinished)
        //{
        //    switch (colorType) {
        //        case "red":
        //            camera.isLevelCamera = false;
        //            player.inMinigame = true;
        //            SceneManager.LoadScene("Red minigame");
        //            break;
        //        case "blue":
        //            camera.isLevelCamera = false;
        //            player.inMinigame = true;
        //            SceneManager.LoadScene("Blue minigame");
        //            break;
        //        case "green":
        //            camera.isLevelCamera = false;
        //            player.inMinigame = true;
        //            SceneManager.LoadScene("Green minigame");
        //            break;
        //        case "yellow":
        //            camera.isLevelCamera = false;
        //            player.inMinigame = true;
        //            SceneManager.LoadScene("Yellow minigame");
        //            break;
        //    }
        //}
	}
}
