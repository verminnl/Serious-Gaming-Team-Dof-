using UnityEngine;

/// <summary>
/// Spawns an enemy in the red minigame
/// </summary>
public class EnemySpawner : MonoBehaviour {
    //Point where enemy starts spawning
    public Transform generationPoint;
    //Distance between each enemy
    public float distanceBetween;
    //Minimal distance between each enemy
    public float distanceBetweenMin;
    //Maximum distance between each enemy
    public float distanceBetweenMax;
    //Chooses which enemy to spawn
    private int enemySelector;
    //Keeps the spawned enemies in an array of ObjectPooler
    public ObjectPooler[] theObjectPools;
    //Lowest x-coordinate for spawning enemies
    private float minX;
    //Gameobject that decides the highest x-coordinate for spawning enemies
    public Transform maxXPoint;
    //Highest x-coordinate for spawning enemies
    private float maxX;
    //Minimum X-value for the spawn point
    public GameObject spawnPointMinX;
    //Maximum X-value for the spawn point
    public GameObject spawnPointMaxX;
    //Distance between the enemies that will be spawned in the x-coordinate
    private float xChange;
    //Minimum number of enemies to spawn at once
    public int minNumberOfEnemiesToSpawn;
    //Maximum number of enemies to spawn at once
    public int maxNumberOfEnemiesToSpawn;
    //Number of enemies to spawn
    private int totalNumberEnemiesToSpawn;

	// Use this for initialization
	void Start () {
        minX = transform.position.x;
        maxX = maxXPoint.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        //Decides the number of enemies to spawn with the given minimum and maximum
        totalNumberEnemiesToSpawn = Random.Range(minNumberOfEnemiesToSpawn, maxNumberOfEnemiesToSpawn + 1);

        //If the y-coordinate of the current connected gameobject is at the y-coordinate of the spawnpoint,
        //spawn a enemy
        if (transform.position.y < generationPoint.position.y)
        {
            //Decides the distance between each enemy in the y-coordinate
            distanceBetween = (Random.Range(distanceBetweenMin, distanceBetweenMax));

            //Spawns a number of enemies based on the totalNumberEnemiesToSpawn
            for (int i = 0; i < totalNumberEnemiesToSpawn; i++)
            {
                //Chooses an enemy to spawn
                enemySelector = Random.Range(0, theObjectPools.Length);
                //Decides how much distance there should be between the enemies in the x-coordinate
                xChange = Random.Range(spawnPointMinX.transform.position.x, spawnPointMaxX.transform.position.x);

                //Makes sure that the enemies don't spawn outside of the given area
                if (xChange > maxX)
                {
                    xChange = maxX;
                }
                else if (xChange < minX)
                {
                    xChange = minX;
                }

                //Sets the position of the spawnpoint
                transform.position = new Vector3(xChange, transform.position.y + distanceBetween, transform.position.z);
                //Gets the enemy that will be spawned based on the enemySelector
                GameObject newEnemy = theObjectPools[enemySelector].GetPooledObject();
                //Sets the position of the enemy to be equal to the spawnpoint
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

                //Sets the state of the enemy to active and with their given velocity
                newEnemy.SetActive(true);
                newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -theObjectPools[enemySelector].moveSpeed);
            }
        }
	}
}
