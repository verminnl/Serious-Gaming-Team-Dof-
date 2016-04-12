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
    public float maxXChange;
    private float xChange;

    public int minNumberOfEnemiesToSpawn;
    public int maxNumberOfEnemiesToSpawn;
    private int totalNumberEnemiesToSpawn;

	// Use this for initialization
	void Start () {
        minX = transform.position.x;
        maxX = maxXPoint.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        totalNumberEnemiesToSpawn = Random.Range(minNumberOfEnemiesToSpawn, maxNumberOfEnemiesToSpawn + 1);

        if (transform.position.y < generationPoint.position.y)
        {
            distanceBetween = (Random.Range(distanceBetweenMin, distanceBetweenMax) / totalNumberEnemiesToSpawn);


            for (int i = 0; i < totalNumberEnemiesToSpawn; i++)
            {
                enemySelector = Random.Range(0, theObjectPools.Length);

                xChange = transform.position.x + Random.Range(maxXChange, -maxXChange);

                if (xChange > maxX)
                {
                    xChange = maxX;
                }
                else if (xChange < minX)
                {
                    xChange = minX;
                }

                transform.position = new Vector3(xChange, transform.position.y + distanceBetween, transform.position.z);

                //Instantiate(enemy, transform.position, transform.rotation);
                GameObject newEnemy = theObjectPools[enemySelector].GetPooledObject();

                newEnemy.transform.position = transform.position;

                //Statically checks for the clone of the meteorite prefab and changes its rotation
                if (theObjectPools[enemySelector].GetPooledObject().name == "meteorite(Clone)")
                {
                    newEnemy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                }
                else
                {
                    newEnemy.transform.rotation = transform.rotation;
                }
                newEnemy.SetActive(true);
                newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -theObjectPools[enemySelector].moveSpeed);
            }
            
        }
	}
}
