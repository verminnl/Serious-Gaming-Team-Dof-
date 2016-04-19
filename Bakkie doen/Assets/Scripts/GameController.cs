using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps the game in check
/// </summary>
public class GameController : MonoBehaviour {
    //Time that has passed since the start of the game
    private static float playedTime;

    private NPCController theNPC;

    private PlayerController thePlayer;

    private CameraController theCamera;

    private bool chosenMinigame = false;

    private List<NPCClass> npcList = new List<NPCClass>();

    public GameObject theLoadingTransition;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Counts the time that has passed
        playedTime += Time.deltaTime;
        TimePassed();

        if (Mathf.FloorToInt(playedTime) == 18)
        {
            Debug.Log("-----------------------------------------------------");
            theLoadingTransition.SetActive(true);
        }
        else if (Mathf.FloorToInt(playedTime) == 20)
        {
            ActivateMinigame();
            chosenMinigame = true;
        }
	}

    public void ActivateMinigame()
    {
        if (!chosenMinigame)
        {
            int npc = Random.Range(0, DialogueClass.Instance.GetNPCDictionaryLength());
            Debug.Log("Random number: " + npc);

            switch (npcList[npc].type)
            {
                case "red":
                    theCamera.isLevelCamera = false;
                    thePlayer.inMinigame = true;
                    SceneManager.LoadScene("Red minigame");
                    break;
                case "blue":
                    theCamera.isLevelCamera = false;
                    thePlayer.inMinigame = true;
                    SceneManager.LoadScene("Blue minigame");
                    break;
                case "green":
                    theCamera.isLevelCamera = false;
                    thePlayer.inMinigame = true;
                    SceneManager.LoadScene("Green minigame");
                    break;
                case "yellow":
                    theCamera.isLevelCamera = false;
                    thePlayer.inMinigame = true;
                    SceneManager.LoadScene("Yellow minigame");
                    break;
            }            
        }
    }

    public void AddNPCToList(NPCClass theNPC)
    {
        npcList.Add(theNPC);
        Debug.Log("NPC added");
    }

    public void TimePassed()
    {
        Debug.Log("Amount of time played: " + playedTime);
    }
}
