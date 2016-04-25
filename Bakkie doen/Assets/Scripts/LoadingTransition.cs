using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
    //NPC sprite box
    public Image npcImageBox;
    //Sprite of an NPC
    public Sprite npcSprite;
    //NPC name box
    public Text npcNameBox;
    //Name of an NPC
    public string npcName;
    //NPC skills box
    public Text npcSkillsBox;
    //Array with skills of an NPC
    public List<string> npcSkills;
    //Checks if the skills of the NPC has been printed on the loading screen
    private bool skillsPrinted = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //Rotates the image on the loading screen
        theLoadingImage.rectTransform.Rotate(new Vector3(0, imageRotateSpeed * Time.deltaTime, 0));
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
        //Shows the skills of the interacted NPC/random NPC on the loading screen
        if (npcSkills != null && !skillsPrinted)
        {
            for (int i = 0; i < npcSkills.Count; i++)
            {
                npcSkillsBox.text = npcSkillsBox.text + npcSkills[i] + "\n";
            }
            skillsPrinted = true;
        }
	}
}
