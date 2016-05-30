using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadingTransition : MonoBehaviour {
    //Image for the loading screen
    public Image theLoadingImage;
    //Speed for the rotation of the image
    public float imageRotateSpeed;
    //How long the loading screen should last
    public float loadingTime;
    //When to start a loading screen based on time in seconds
    public float timeToStartLoadingScreen;
    //Check if the player has found an NPC
    private bool playerHasFoundNPC;
    //Text for the encounter with NPC
    public Text encounterNPC;
    //NPC sprite box
    public Image npcImageBox;
    //Sprite of an NPC
    public Sprite npcSprite;
    //NPC name box
    public Text npcNameBox;
    //Name of an NPC
    public string npcName;
    //Room number box
    public Text npcRoomBox;
    //Room of an NPC
    public string npcRoom;
    //NPC skills box
    public Text npcSkillsBox;
    //Array with skills of an NPC
    public List<string> npcSkills;
    //Checks if the skills of the NPC has been printed on the loading screen
    //private bool skillsPrinted = false;
    //Checks if the loading screen has been printed
    private bool loadingScreenPrinted = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //Rotates the image on the loading screen
        theLoadingImage.rectTransform.Rotate(new Vector3(0, imageRotateSpeed * Time.deltaTime, 0));
        //Makes sure that the items on the loading screen will only be printed once
        if (loadingScreenPrinted)
        {
            return;
        }
        else
        {
            //Shows if the player has found the NPC or if it was a random encounter NPC
            if (playerHasFoundNPC)
            {
                encounterNPC.text = "Je hebt de volgende persoon gevonden!";
            }
            else
            {
                encounterNPC.text = "De volgende persoon heeft jouw gevonden!";
            }
            //Shows the interacted NPC/random NPC on the loading screen
            if (npcImageBox != null)
            {
                npcImageBox.sprite = npcSprite;
            }
            //Shows the name of the interacted NPC/random NPC on the loading screen
            if (npcNameBox != null)
            {
                npcNameBox.text = npcName;
            }
            //Shows the room of the interacted NPC/random NPC on the loading screen
            if (npcRoomBox != null)
            {
                npcRoomBox.text = npcRoomBox.text + npcRoom;
            }
            //Shows the skills of the interacted NPC/random NPC on the loading screen
            if (npcSkills != null)
            {
                for (int i = 0; i < npcSkills.Count; i++)
                {
                    npcSkillsBox.text = npcSkillsBox.text + npcSkills[i] + "\n";
                }
            }
            loadingScreenPrinted = true;
        }
	}

    public void HasThePlayerFoundNPC(bool foundNPC)
    {
        playerHasFoundNPC = foundNPC;
    }
}
