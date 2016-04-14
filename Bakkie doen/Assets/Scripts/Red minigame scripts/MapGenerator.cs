using UnityEngine;
using System.Collections;

/// <summary>
/// Generates the map in the red minigame
/// </summary>
public class MapGenerator : MonoBehaviour {
    //Point where enemy starts spawning
    public Transform generationPoint;
    //Distance between each enemy
    //If the distance should be the height of a tiled map, it can be found in the prefabs folder
    //of Tiled2Unity at the Component "Tiled Map" -> "Map Height in Pixels"
    public float distanceBetween;
    //Index of the map in the object pooling system
    private int indexOfMap;
    //Keeps the spawned enemies in an array of ObjectPooler
    public ObjectPooler theObjectPool;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the y-coordinate of the current connected gameobject is at the y-coordinate of the spawnpoint,
        //spawn a enemy
        if (transform.position.y < generationPoint.position.y)
        {
            //Sets the position of the spawnpoint
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetween, transform.position.z);
            //Gets the enemy that will be spawned based on the enemySelector
            GameObject newEnemy = theObjectPool.GetPooledObject();

            //Sets the position of the enemy to be equal to the spawnpoint
            newEnemy.transform.position = transform.position;
            newEnemy.transform.rotation = transform.rotation;

            //Sets the state of the enemy to active and with their given velocity
            newEnemy.SetActive(true);

        }
    }
}
