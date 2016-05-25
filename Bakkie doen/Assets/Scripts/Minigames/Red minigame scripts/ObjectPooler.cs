using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// An object pooling system to reduce processing time
/// </summary>
public class ObjectPooler : MonoBehaviour {
    //Gameobject that will be added to the object pooling system
    public GameObject pooledObject;
    //The movement speed of the object
    public float moveSpeed;
    //Amount of the gameobject that will be added to the object pooling system at the start of the game
    public int pooledAmount;
    //List with all the gameobjects (the object pooling system)
    List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>();

        //Adds the amount of gameobjects that should be in the object pooling system at the start of the game
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}

    /// <summary>
    /// Gets an object from the object pooling system
    /// </summary>
    /// <returns>Returns a gameobject</returns>
    public GameObject GetPooledObject()
    {
        //Goes through the object pooling system
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //If there is an inactive gameobject in the Hierarchy, return it
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        //If there are no inactive gameobjects in the Hierarchy
        //Creates a new one and adds it to the object pooling system
        //Returns the newly created gameobject
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
