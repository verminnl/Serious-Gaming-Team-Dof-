using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform generationPoint;
    public float distanceBetween;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int enemySelector;

    public ObjectPooler[] theObjectPools;

    private float minX;
    public Transform maxXPoint;
    private float maxX;

	// Use this for initialization
	void Start () {
        minX = transform.position.x;
        maxX = maxXPoint.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < generationPoint.position.y)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            enemySelector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetween, transform.position.z);

            //Instantiate(enemy, transform.position, transform.rotation);
            GameObject newEnemy = theObjectPools[enemySelector].GetPooledObject();

            newEnemy.transform.position = transform.position;
            if (theObjectPools[enemySelector].GetPooledObject().name == "meteorite(Clone)")
            {
                newEnemy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            }
            else
            {
                newEnemy.transform.rotation = transform.rotation;
            }
            newEnemy.SetActive(true);
        }
	}
}
