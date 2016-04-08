using UnityEngine;
using System.Collections;

public class OwnMazeGenerator : MonoBehaviour {

    public int mazeSquareSize;

    public int[,] mazeCellDatabase;

	// Use this for initialization
	void Start () {
        mazeSquareSize = 21;
        mazeCellDatabase = new int [mazeSquareSize, mazeSquareSize];

        fillCellDatabase();
    }

    void fillCellDatabase()
    {

        GameObject newSprite = new GameObject();
        newSprite.AddComponent<SpriteRenderer>();
        for (int i = 0; i < mazeSquareSize; i++)
        {
            for (int j = 0; j < mazeSquareSize; j++)
            {
                //Buitenranden afvangen
                if (i == 0 || j == 0 || i == mazeSquareSize - 1 || j == mazeSquareSize - 1)
                {
                    mazeCellDatabase[i, j] = 0;
                }
                //Binnengebied random invullen
                else
                {
                    if ((int)Random.Range(0f, 100f) < 50f)
                    {
                        mazeCellDatabase[i, j] = 0;
                    }
                    else
                    {
                        mazeCellDatabase[i, j] = 1;
                    }
                }
            }
        }

        // Refinen van ritme
        for (int i = 0; i < mazeSquareSize; i++)
        {
            for (int j = 0; j < mazeSquareSize; j++)
            {
                // Refine
                if (i > 1 && i < mazeSquareSize - 2 && j > 1 && j < mazeSquareSize - 2)
                {
                    /*
                    print(mazeSquareSize - 3);
                    //[1][2][3]
                    //[4][x][5]
                    //[6][7][8]
                    int livingCellCounter = 0;
                    //1
                    if (mazeCellDatabase[i - 1, j + 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    //2
                    if (mazeCellDatabase[i, j + 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    //3
                    if (mazeCellDatabase[i + 1, j + 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    //4
                    if (mazeCellDatabase[i - 1, j] == 1)
                    {
                        livingCellCounter++;
                    }
                    //5
                    if (mazeCellDatabase[i + 1, j] == 1)
                    {
                        livingCellCounter++;
                    }
                    //6
                    if (mazeCellDatabase[i - 1, j - 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    //7
                    if (mazeCellDatabase[i, j - 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    //8
                    if (mazeCellDatabase[i + 1, j - 1] == 1)
                    {
                        livingCellCounter++;
                    }
                    if (livingCellCounter > 5)
                    {
                        mazeCellDatabase[i, j] = 0;
                    }

                    */
                    //Tekenen
                    if (mazeCellDatabase[i, j] == 0)
                    {
                        newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("groen").GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("grijs").GetComponent<SpriteRenderer>().sprite;
                    }
                    newSprite.transform.position = new Vector3(j, i);
                    Instantiate(newSprite);
                }
            }
        }
    }

    /*void drawCellDatabase()
    {

        for (int i = 0; i < mazeRowWidth; i++)
        {
            for (int j = 0; j < mazeColumWidth; j++)
            {
                if (mazeCellDatabase[i, j] == 0)
                {
                    newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("groen").GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("grijs").GetComponent<SpriteRenderer>().sprite;
                }
                newSprite.transform.position = new Vector3(j, i);
                Instantiate(newSprite);
            }
        }
    }*/
	
	// Update is called once per frame
	void Update () {
	
	}
}
