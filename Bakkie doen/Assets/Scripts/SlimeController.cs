using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    public float timeToMove;
    private Vector3 moveDirection;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
    
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 2f);
        timeToMoveCounter = Random.Range(timeToMoveCounter * 0.75f, timeToMoveCounter * 2f);
    }
	
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 2f);
            }
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
            timeBetweenMoveCounter -= Time.deltaTime;
            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeBetweenMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMoveCounter * 0.75f, timeToMoveCounter * 2f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                reloading = false;
                thePlayer.gameObject.SetActive(true);
                waitToReload = 2;
                
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);

            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }
    }

    
}
