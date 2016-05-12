using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps the game in check
/// </summary>
public class GameController : MonoBehaviour {
    //Time that has passed since the start of the game
    private static float playedTime;
    //Player Data Model
    public static AvatarData playerData;
    //Player Login Model
    public static PlayerLogin playerLogin;
    //NPC dictionairy
    public static List<AvatarData> npcData;
    //Counts the time after finishing dialogue with an NPC
    private float npcMinigameStartCounter;
    //Current player
    private PlayerController thePlayer;
    //Current camera
    private CameraController theCamera;
    //List with all the NPCs in the game
    private static List<NPCController> npcList = new List<NPCController>();
    //Index number of the NPC in the List<NPCClass> npcList
    private int indexNumberNPC;
    //Check if a random NPC has been chosen
    private bool hasChosenRandomNPC = false;
    //Loading screen for the game
    public GameObject theLoadingTransition;
    //Time for the loading screen to be active
    private float loadingScreenTime;
    //Time for the loading screen to appear
    private float startLoading;
    //Checks if a the gamecontroller already exists
    private bool gcExists;

    //Sets the loadingScreenTime and the startLoading variables to the values that has been given in the Inspector
    //at the LoadingTransition script
    void Awake()
    {
        if (theLoadingTransition != null)
        {
            theLoadingTransition.SetActive(true);
            loadingScreenTime = FindObjectOfType<LoadingTransition>().loadingTime;
            startLoading = FindObjectOfType<LoadingTransition>().timeToStartLoadingScreen;
            theLoadingTransition.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();

        //Counts the time that has passed
        playedTime += Time.deltaTime;

        //When the player is talking to an NPC, set minigameType to the colorType of the NPC
        if (PlayerActionDataTracking.theNPC != null)
        {
            //When finished talking to an NPC, start the loading screen and start a time counter
            if (PlayerActionDataTracking.theNPC.dialogueFinished)
            {
                theLoadingTransition.SetActive(true);
                theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = PlayerActionDataTracking.theNPC.GetComponent<SpriteRenderer>().sprite;
                theLoadingTransition.GetComponent<LoadingTransition>().npcName = PlayerActionDataTracking.theNPC.GetComponent<NPCController>().name;
                theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = PlayerActionDataTracking.theNPC.GetComponent<NPCController>().roomNumber;
                theLoadingTransition.GetComponent<LoadingTransition>().npcSkills = PlayerActionDataTracking.theNPC.GetComponent<NPCController>().NPCSkills;
                npcMinigameStartCounter += Time.deltaTime;

                //When the time counter is higher than the loadingScreenTime, start the minigame based on minigameType
                if (npcMinigameStartCounter > loadingScreenTime)
                {
                    ActivateMinigame(PlayerActionDataTracking.theNPC.GetComponent<NPCController>().colorType);
                }
            }
        }

        TimePassed();

        //Start loading screen if player hasn't talked to an NPC for {startLoading} seconds and
        //activate minigame after {loadingScreenTime} seconds
        if (Mathf.FloorToInt(playedTime) == startLoading)
        {
            if (!hasChosenRandomNPC)
            {
                indexNumberNPC = randomMinigameColor();
                hasChosenRandomNPC = true;
            }

            PlayerActionDataTracking.theNPC = npcList[indexNumberNPC];
            theLoadingTransition.SetActive(true);

            //Sends the information of the NPC to the loading screen
            theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = PlayerActionDataTracking.theNPC.sprite;
            theLoadingTransition.GetComponent<LoadingTransition>().npcName = PlayerActionDataTracking.theNPC.name;
            theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = PlayerActionDataTracking.theNPC.roomNumber;
            theLoadingTransition.GetComponent<LoadingTransition>().npcSkills = PlayerActionDataTracking.theNPC.NPCSkills;
        }
        else if (Mathf.FloorToInt(playedTime) == startLoading + loadingScreenTime)
        {
            ActivateMinigame(PlayerActionDataTracking.theNPC.colorType);
        }
	}

    /// <summary>
    /// Gets a random NPC index from npcList
    /// </summary>
    /// <returns>An index of a random NPC</returns>
    int randomMinigameColor()
    {
        int npc = Random.Range(0, npcList.Count);
        Debug.Log("Random number: " + npc);
        return npc;
    }

    /// <summary>
    /// Activates a minigame based on the type in the main level
    /// </summary>
    /// <param name="type">Type of the minigame</param>
    public void ActivateMinigame(string type)
    {
        switch (type)
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

    /// <summary>
    /// Adds the NPCs in the game to npcList
    /// </summary>
    /// <param name="theNPC">NPC that should be added to the list</param>
    public void AddNPCToList(NPCController theNPC)
    {
        // ***************** Still need a check if the npc is already exist in the list or not before adding him
        npcList.Add(theNPC);
    }

    /// <summary>
    /// Displays the time that has passed since the start of the game in the console
    /// </summary>
    public void TimePassed()
    {
        //Debug.Log("Amount of time played: " + playedTime);
    }
}
