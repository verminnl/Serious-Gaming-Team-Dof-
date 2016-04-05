using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour {

    public string colorType;
    public string[] dialogue;
    public bool dialogueFinished;

    public NPCClass npc;

    void Awake()
    {
        npc = new NPCClass(gameObject.name, colorType, dialogue);
    }

	// Use this for initialization
	void Start () {
        print("NPC name: " + npc.name + ", NPC type: " + npc.type + ", Number of NPCs: " + NPCClass.number);
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueFinished)
        {
            switch (colorType) {
                case "red":
                    SceneManager.LoadScene("Red minigame");
                    break;
                case "blue":
                    SceneManager.LoadScene("Blue minigame");
                    break;
                case "green":
                    SceneManager.LoadScene("Green minigame");
                    break;
                case "yellow":
                    SceneManager.LoadScene("Yellow minigame");
                    break;
            }
        }
	}
}
