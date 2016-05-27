using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Keeps the game in check
/// </summary>
public class GameController : MonoBehaviour {
    //Time that has passed since the start of the game
    public static float playedTime;
    //Counts the time after finishing dialogue with an NPC
    private float npcMinigameStartCounter;
    //Current player
    private PlayerController thePlayer;
    //Current camera
    private CameraController theCamera;
    //Loading screen for the game
    public GameObject theLoadingTransition;
    //Time for the loading screen to be active
    private float loadingScreenTime;
    //Time for the loading screen to appear
    private float startLoading;
    //
    AvatarData randomNPC;
    public List<NPCController> npcList;

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
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
      
        //Counts the time that has passed
        playedTime += Time.deltaTime;

        //When the player is talking to an NPC, set minigameType to the colorType of the NPC
        if (DataTracking.currentNPC != null)
        {
            //When finished talking to an NPC, start the loading screen and start a time counter
            if (DataTracking.currentNPC.dialogueFinished)
            {
                AvatarData currentNPCAvatar = DataTracking.currentNPC.GetComponent<NPC>().avatar;
                theLoadingTransition.SetActive(true);
                theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = DataTracking.currentNPC.GetComponent<SpriteRenderer>().sprite;
                theLoadingTransition.GetComponent<LoadingTransition>().npcName = currentNPCAvatar.FullName;
                theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = currentNPCAvatar.Room;
                npcMinigameStartCounter += Time.deltaTime;

                //When the time counter is higher than the loadingScreenTime, start the minigame based on minigameType
                if (npcMinigameStartCounter > loadingScreenTime)
                {
                    ActivateMinigame(currentNPCAvatar.Element);
                }
            }
        }

        //Start loading screen if player hasn't talked to an NPC for {startLoading} seconds and
        //activate minigame after {loadingScreenTime} seconds
        if (Mathf.FloorToInt(playedTime) == startLoading)
        {
            if(DataTracking.randomNPC == null)
            {
                DataTracking.randomNPC = DataTracking.npcData[Random.Range(0, DataTracking.npcData.Count)];
            }
            DataTracking.currentNPC = gameObject.AddComponent<NPC>();
            DataTracking.currentNPC.avatar = DataTracking.randomNPC;
            randomNPC = DataTracking.currentNPC.avatar;
            theLoadingTransition.SetActive(true);

            //Sends the information of the NPC to the loading screen
            theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = NPCSetSprite();
            theLoadingTransition.GetComponent<LoadingTransition>().npcName = randomNPC.FullName;
            theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = randomNPC.Room;
            foreach (string item in randomNPC.Skills)
            {
                theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(item);
            }
        }
        else if (Mathf.FloorToInt(playedTime) == startLoading + loadingScreenTime)
        {
            ActivateMinigame(DataTracking.currentNPC.avatar.Element);
        }
	}

    /// <summary>
    /// Gets a random NPC index from npcList
    /// </summary>
    /// <returns>An index of a random NPC</returns>
    int randomMinigameColor()
    {
        int npc = Random.Range(0, DataTracking.npcData.Count);
        return npc;
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
    /// Activates a minigame based on the type in the main level
    /// </summary>
    /// <param name="type">Type of the minigame</param>
    public void ActivateMinigame(string type)
    {
        string spawn = SceneManager.GetActiveScene().name + "_" + thePlayer.transform.position.x + "_" + thePlayer.transform.position.y;
        Debug.Log(spawn);
        BackEndCommunicator.Instance.SaveSpawnLocation(DataTracking.playerData.PlayerID, spawn, DataTracking.playerData.SessionID);
        type = (type == "red" ? "Red minigame" : "Blue minigame");
        theCamera.isLevelCamera = false;
        thePlayer.inMinigame = true;
        SceneManager.LoadScene(type);
    }

    public Sprite NPCSetSprite()
    {
        Sprite sprite = new Sprite();
        if (Resources.Load<Sprite>("Characters/" + randomNPC.Character))
        {
            sprite = Resources.Load<Sprite>("Characters/" + randomNPC.Character);
        }
        return sprite;
    }
}