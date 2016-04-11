using UnityEngine;
using System.Collections;

public class EnemyDestroyer : MonoBehaviour {

    public GameObject enemyDestructionPoint;

	// Use this for initialization
	void Start () {
        enemyDestructionPoint = GameObject.Find("Enemy Destruction Point");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < enemyDestructionPoint.transform.position.y)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}
