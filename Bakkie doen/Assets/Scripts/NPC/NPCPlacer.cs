using UnityEngine;

/// <summary>
/// Places NPCs on some given positions of gameobjects
/// </summary>
public class NPCPlacer : MonoBehaviour {
    //Locations for NPCs to be placed
    public GameObject[] locations;
    //A random NPC from the database
    public AvatarData randomNPC;
    
    // Use this for initialization
    void Start () {
        //Places a random NPC on each of the given locations
        foreach (GameObject location in locations)
        {
            randomNPC = DataTracking.npcData[Random.Range(0, DataTracking.npcData.Count - 1)];
            location.GetComponent<NPC>().avatar = randomNPC;
            location.GetComponent<SpriteRenderer>().sprite = randomNPC.NPCSprite;
        }
    }
}