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
    //Checks if the dialogue is finished or not
    public bool dialogueFinished;
    //Checks if the player is in the elevator menu or not
    public bool inElevator;

    //Sets the loadingScreenTime and the startLoading variables to the values that has been given in the Inspector
    //at the LoadingTransition script
    void Awake()
    {
        if(DataTracking.playerData == null)
        {
            SceneManager.LoadScene("Login");
            return;
        }
        if (theLoadingTransition != null)
        {
            theLoadingTransition.SetActive(true);
            loadingScreenTime = FindObjectOfType<LoadingTransition>().loadingTime;
            startLoading = FindObjectOfType<LoadingTransition>().timeToStartLoadingScreen;
            theLoadingTransition.SetActive(false);
        }
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            Vector3 scale = go.transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        dialogueFinished = false;
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DataTracking.currentNPC != null)
        {
            //When finished talking to an NPC, start the loading screen and start a time counter
            if (dialogueFinished)
            {
                npcMinigameStartCounter += Time.deltaTime;
                if (theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Count == 0)
                {
                    theLoadingTransition.SetActive(true);
                    theLoadingTransition.GetComponent<LoadingTransition>().HasThePlayerFoundNPC(true);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = DataTracking.currentNPC.NPCSprite;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcName = DataTracking.currentNPC.FullName;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = DataTracking.currentNPC.Room;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.currentNPC.Skill1);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.currentNPC.Skill2);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.currentNPC.Skill3);
                }

                //When the time counter is higher than the loadingScreenTime, start the minigame based on minigameType
                if (npcMinigameStartCounter > loadingScreenTime)
                {
                    ActivateMinigame(DataTracking.currentNPC.Element);
                }
            }
        }
        else if (inElevator) { }
        else
        {
            playedTime += Time.deltaTime;
            if (playedTime > startLoading + loadingScreenTime)
            {
                ActivateMinigame(DataTracking.randomNPC.Element);
            }
            else if (playedTime > startLoading)
            {
                if (theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Count == 0)
                {
                    theLoadingTransition.SetActive(true);

                    //Sends the information of the NPC to the loading screen
                    theLoadingTransition.GetComponent<LoadingTransition>().HasThePlayerFoundNPC(false);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSprite = DataTracking.randomNPC.NPCSprite;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcName = DataTracking.randomNPC.FullName;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcRoom = DataTracking.randomNPC.Room;
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.randomNPC.Skill1);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.randomNPC.Skill2);
                    theLoadingTransition.GetComponent<LoadingTransition>().npcSkills.Add(DataTracking.randomNPC.Skill3);
                }
            }
        }
    }

    /// <summary>
    /// Activates a minigame based on the type in the main level
    /// </summary>
    /// <param name="type">Type of the minigame</param>
    public void ActivateMinigame(string type)
    {
        string spawn = SceneManager.GetActiveScene().name + "_" + thePlayer.transform.position.x + "_" + thePlayer.transform.position.y;
        DataTracking.playerData.SpawnPoint = spawn;
        type = (type == "red" ? "Red minigame" : "Blue minigame");
        theCamera.isLevelCamera = false;
        thePlayer.inMinigame = true;
        SceneManager.LoadScene(type);
    }    
}