using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Controls the behaviour and the details of the loading screen in the game
/// </summary>
public class LoadingTransition : MonoBehaviour {
    //Image for the loading screen
    public Image theLoadingImage;
    //Speed for the rotation of the image
    public float imageRotateSpeed;
    //Loading text box
    public Text loadingBox;
    //How long the loading screen should last
    public float loadingTime;
    //When to start a loading screen based on time in seconds
    public float timeToStartLoadingScreen;
    //Time that the loading screen has been active
    private float timeActive = 0f;
    //Percentage for the loading screen
    private int percentage;
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
    //Checks if the loading screen has been printed
    private bool loadingScreenPrinted = false;
	
	// Update is called once per frame
	void Update () {
        //Rotates the image on the loading screen
        theLoadingImage.rectTransform.Rotate(new Vector3(0, imageRotateSpeed * Time.deltaTime, 0));
        //Prints the loading percentage on the loading screen
        timeActive += Time.deltaTime;
        percentage = (int) Mathf.Ceil((100 / loadingTime) * timeActive);
        //Makes sure that the percentage won't go over 100%
        if (percentage > 100)
        {
            percentage = 100;
        }
        loadingBox.text = "Laden...." + percentage + "%";

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
                encounterNPC.text = "Iemand heeft jou gevonden!";
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

    /// <summary>
    /// Sets the {playerHasFoundNPC} variable
    /// </summary>
    /// <param name="foundNPC">Checks if the player has found an NPC or not</param>
    public void HasThePlayerFoundNPC(bool foundNPC)
    {
        playerHasFoundNPC = foundNPC;
    }
}
