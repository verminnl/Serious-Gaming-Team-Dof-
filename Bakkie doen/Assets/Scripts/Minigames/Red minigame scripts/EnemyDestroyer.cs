using UnityEngine;

/// <summary>
/// Removes a gameobject when it reaches a point
/// </summary>
public class EnemyDestroyer : MonoBehaviour {
    //A gameobject that removes another gameobject when it reaches it
    public GameObject enemyDestructionPoint;

	// Use this for initialization
	void Start () {
        //Finds the gameobject named "Enemy Destruction Point" in the game
        enemyDestructionPoint = GameObject.Find("Enemy Destruction Point");
	}
	
	// Update is called once per frame
	void Update () {
        //When an enemy gameobject reaches the y-position of the "Enemy Destruction Point",
        //set the state of the enemy object to inactive
        if (transform.position.y < enemyDestructionPoint.transform.position.y)
        {
            gameObject.SetActive(false);
        }
	}
}
