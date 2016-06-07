using UnityEngine;

/// <summary>
/// Generates the map in the red minigame
/// </summary>
public class MapGenerator : MonoBehaviour {
    //Point where map starts spawning
    public Transform generationPoint;
    //Distance between each map
    //If the distance should be the height of a tiled map, it can be found in the prefabs folder
    //of Tiled2Unity at the Component "Tiled Map" -> "Map Height in Pixels"
    public float distanceBetween;
    //Keeps the generated maps in an array of ObjectPooler
    public ObjectPooler theObjectPool;

    // Update is called once per frame
    void Update()
    {
        //If the y-coordinate of the current connected gameobject is at the y-coordinate of the generationpoint,
        //generate a map
        if (transform.position.y < generationPoint.position.y)
        {
            //Sets the position of the generationpoint
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetween, transform.position.z);
            //Gets the map that will be generated
            GameObject newMap = theObjectPool.GetPooledObject();

            //Sets the position of the map to be equal to the generationpoint
            newMap.transform.position = transform.position;
            newMap.transform.rotation = transform.rotation;

            //Sets the state of the map to active
            newMap.SetActive(true);
        }
    }
}
