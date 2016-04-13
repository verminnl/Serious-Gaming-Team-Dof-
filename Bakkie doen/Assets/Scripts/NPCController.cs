using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour {

    public string colorType;
    public string[] dialogue;
    public bool dialogueFinished;

    public NPCClass npc;
    private CameraController camera;
    private PlayerController player;

    void Awake()
    {
        npc = new NPCClass(gameObject.name, colorType, dialogue);
        camera = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerController>();
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
                    camera.isLevelCamera = false;
                    player.inMinigame = true;
                    SceneManager.LoadScene("Red minigame");
                    break;
                case "blue":
                    camera.isLevelCamera = false;
                    player.inMinigame = true;
                    SceneManager.LoadScene("Blue minigame");
                    break;
                case "green":
                    camera.isLevelCamera = false;
                    player.inMinigame = true;
                    SceneManager.LoadScene("Green minigame");
                    break;
                case "yellow":
                    camera.isLevelCamera = false;
                    player.inMinigame = true;
                    SceneManager.LoadScene("Yellow minigame");
                    break;
            }
        }
	}
}
