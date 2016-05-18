using UnityEngine;
using System.Collections;

public class mazeController : MonoBehaviour {

    public GameObject start;
    public GameObject finish;
    public GameObject maze1;
    public GameObject maze2;
    public GameObject maze3;
    public GameObject maze4;
    public GameObject maze5;

	// Use this for initialization
	void Start () {
        InitialiseMaze();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitialiseMaze()
    {
        int randomMaze = Random.Range(1, 6);
        print("maze_" + randomMaze);
        GameObject maze = GameObject.FindGameObjectWithTag("maze_" + randomMaze);

        int randomStart = 1;
        int randomFinish = 1;
        int reverseFinishAndStart = Random.Range(0, 2);
        if (reverseFinishAndStart == 1)
        {
            GameObject temp = start;
            start = finish;
            finish = temp;
        }
        deactivateMazes(randomMaze);
        switch (randomMaze)
        {
            case 1:
                randomStart = Random.Range(1, 3);
                switch (randomStart)
                {
                    case 1:
                        start.transform.position = new Vector3(3.13f, -3.2f);
                        break;
                    case 2:
                        start.transform.position = new Vector3(17.4f, -8f);
                        break;
                }
                randomFinish = Random.Range(1, 4);
                switch (randomFinish)
                {
                    case 1:
                        finish.transform.position = new Vector3(12.73f, -22.44f);
                        break;
                    case 2:
                        finish.transform.position = new Vector3(17.62f, -22.44f);
                        break;
                    case 3:
                        finish.transform.position = new Vector3(3.28f, -22.44f);
                        break;
                }
                break;
            case 2:
                randomStart = Random.Range(1, 3);
                switch (randomStart)
                {
                    case 1:
                        start.transform.position = new Vector3(22.22f, -22.45f);
                        break;
                    case 2:
                        start.transform.position = new Vector3(12.74f, -22.45f);
                        break;
                }
                randomFinish = Random.Range(1, 4);
                switch (randomFinish)
                {
                    case 1:
                        finish.transform.position = new Vector3(12.84f, -8.21f);
                        break;
                    case 2:
                        finish.transform.position = new Vector3(3.2f, -3.47f);
                        break;
                    case 3:
                        finish.transform.position = new Vector3(12.91f, -8.14f);
                        break;
                }
                break;
            case 3:
                randomStart = Random.Range(1, 3);
                switch (randomStart)
                {
                    case 1:
                        start.transform.position = new Vector3(22.22f, -22.45f);
                        break;
                    case 2:
                        start.transform.position = new Vector3(12.74f, -22.45f);
                        break;
                }
                randomFinish = Random.Range(1, 3);
                switch (randomFinish)
                {
                    case 1:
                        finish.transform.position = new Vector3(17.73f, -8.14f);
                        break;
                    case 2:
                        finish.transform.position = new Vector3(8.09f, -12.88f);
                        break;
                }
                break;
            case 4:
                randomStart = Random.Range(1, 3);
                switch (randomStart)
                {
                    case 1:
                        start.transform.position = new Vector3(22.31f, -22.68f);
                        break;
                    case 2:
                        start.transform.position = new Vector3(22.31f, -3.3f);
                        break;
                }
                randomFinish = Random.Range(1, 4);
                switch (randomFinish)
                {
                    case 1:
                        finish.transform.position = new Vector3(12.74f, -22.45f);
                        break;
                    case 2:
                        finish.transform.position = new Vector3(8.24f, -18f);
                        break;
                }
                break;
            case 5:
                randomStart = Random.Range(1, 3);
                switch (randomStart)
                {
                    case 1:
                        start.transform.position = new Vector3(12.59f, -22.62f);
                        break;
                    case 2:
                        start.transform.position = new Vector3(3.05f, -22.5f);
                        break;
                }
                randomFinish = Random.Range(1, 3);
                switch (randomFinish)
                {
                    case 1:
                        finish.transform.position = new Vector3(17.6f, -17.68f);
                        break;
                    case 2:
                        finish.transform.position = new Vector3(7.87f, -8.11f);
                        break;
                }
                break;
        }
    }

    void deactivateMazes(int maze)
    {
        switch (maze)
        {
            case 1:
                maze1.SetActive(true);
                break;
            case 2:
                maze2.SetActive(true);
                break;
            case 3:
                maze3.SetActive(true);
                break;
            case 4:
                maze4.SetActive(true);
                break;
            case 5:
                maze5.SetActive(true);
                break;
        }
    }
}
