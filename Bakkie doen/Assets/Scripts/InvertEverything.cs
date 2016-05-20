using UnityEngine;
using System.Collections;

public class InvertEverything : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] allGameObjects;
        allGameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject abc in allGameObjects)
        {
            abc.transform.rotation = new Quaternion(180, 0, 0, 0);

            //abc.transform.position = new Vector3(abc.transform.position.x, abc.transform.position.y, abc.transform.position.z * -1);
         }
	}
	
	// Update is called once per 
	void Update () {
	
	}
}
