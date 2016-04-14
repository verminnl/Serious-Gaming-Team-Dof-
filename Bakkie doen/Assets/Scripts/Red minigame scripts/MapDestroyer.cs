using UnityEngine;
using System.Collections;

/// <summary>
/// Removes a gameobject when it reaches a point
/// </summary>
public class MapDestroyer : MonoBehaviour {

    //A gameobject that removes another gameobject when it reaches it
    public GameObject mapDestructionPoint;

    // Use this for initialization
    void Start()
    {
        //Finds the gameobject named "Enemy Destruction Point" in the game
        mapDestructionPoint = GameObject.Find("Map Destruction Point");
    }

    // Update is called once per frame
    void Update()
    {
        //When an enemy gameobject reaches the y-position of the "Enemy Destruction Point",
        //set the state of the enemy object to inactive
        if (transform.position.y < mapDestructionPoint.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
