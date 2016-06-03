using UnityEngine;

public class NPCPlacer : MonoBehaviour {
    public GameObject[] locations;
    public AvatarData randomNPC;
    
    // Use this for initialization
    void Start () {
        foreach (GameObject location in locations)
        {
            randomNPC = DataTracking.npcData[Random.Range(0, DataTracking.npcData.Count - 1)];
            location.GetComponent<NPC>().avatar = randomNPC;
            location.GetComponent<SpriteRenderer>().sprite = randomNPC.NPCSprite;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}