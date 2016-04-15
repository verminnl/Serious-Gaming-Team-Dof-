using UnityEngine;
using System.Collections;

public class OwnMazeGenerator : MonoBehaviour {

    public int mazeSquareSize;

    public int[,] mazeCellDatabase; // Array storin the cell values.
    bool[,] wasHere; // Array storin wether a cell has been acces already or not
    bool[,] correctPath; // The solution to the maze
    int startX, startY; // Starting X and Y values of maze
    int endX, endY;     // Ending X and Y values of maze

    // Use this for initialization
    void Start () {
        mazeSquareSize = 25;
        mazeCellDatabase = new int [mazeSquareSize, mazeSquareSize];
        wasHere = new bool[mazeSquareSize, mazeSquareSize];
        correctPath = new bool[mazeSquareSize, mazeSquareSize];
        startX = 1;
        startY = 1;
        endX = mazeSquareSize - 1;
        endY = mazeSquareSize - 1;

        fillCellDatabase();
        refineCellDatabase();
        solveMaze();
        drawCellDatabase();
    }

    void fillCellDatabase()
    {
        for (int i = 0; i < mazeSquareSize; i++)
        {
            for (int j = 0; j < mazeSquareSize; j++)
            {
                if ( i == 1 && j == 1 || i == mazeSquareSize -1 && j == mazeSquareSize -1)
                {
                    mazeCellDatabase[i, j] = 1;
                }
                //Binnengebied random invullen
                else if ((int)Random.Range(0f, 100f) < 40f)
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

    void refineCellDatabase()
    {
        // Refinen van ritme
        for (int i = 0; i < mazeSquareSize; i++)
        {
            for (int j = 0; j < mazeSquareSize; j++)
            {
                // Refine
                if (i > 1 && i < mazeSquareSize - 1 && j > 1 && j < mazeSquareSize - 1)
                {
                    print(i + "    " + j);
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
                    //Haalt muren weg als er teveel andere muren omheen zijn.
                    if (livingCellCounter > 6)
                    {
                        mazeCellDatabase[i, j] = 1;
                    }
                }
            }
        }
    }

    //This method adds Gameobjects with sprites.
    void drawCellDatabase()
    {
        GameObject newSprite = new GameObject();
        newSprite.AddComponent<SpriteRenderer>();

        for (int i = 0; i < mazeSquareSize; i++)
        {
            for (int j = 0; j < mazeSquareSize; j++)
            {
                //This one adds the green floors
                if (mazeCellDatabase[i, j] == 1)
                {
                    newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("groen").GetComponent<SpriteRenderer>().sprite;
                    newSprite.name = i + " " + j;
                    newSprite.transform.position = new Vector3(j, i);
                    Instantiate(newSprite);
                }
                // THis one draws a grey line when a solution is possible
                if(correctPath[i, j])
                {
                    newSprite.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("grijs").GetComponent<SpriteRenderer>().sprite;
                    newSprite.name = i + " " + j;
                    newSprite.transform.position = new Vector3(j, i, -1);
                    Instantiate(newSprite);
                }
            }
        }
    }

    void solveMaze()
    {
        for (int row = 0; row < mazeSquareSize; row++)
        {
            // Sets boolean Arrays to default values
            for (int col = 0; col < mazeSquareSize; col++)
            {
                wasHere[row, col] = false;
                correctPath[row, col] = false;
            }
        }
        bool b = recursiveSolve(startX, startY);
        print(b);
            // Will leave you with a boolean array (correctPath) 
            // with the path indicated by true values.
            // If b is false, there is no solution to the maze
    }

    public bool recursiveSolve(int x, int y) {
        if (x == endX && y == endY)
        {
            return true; // If you reached the end
        }
        if (mazeCellDatabase[x, y] == 0 || wasHere[x, y])
        {
            return false;
        }
        
        // If you are on a wall or already were here
        wasHere[x, y] = true;
        if (x != 0) // Checks if not on left edge
        {
            if (recursiveSolve(x - 1, y))
            { // Recalls method one to the left
                correctPath[x, y] = true; // Sets that path value to true;
                return true;
            }
        }
        if (x != mazeSquareSize - 1) // Checks if not on right edge
        {
            if (recursiveSolve(x + 1, y))
            { // Recalls method one to the right
                correctPath[x, y] = true;
                return true;
            }
        }
        if (y != 0)  // Checks if not on top edge
        {
            if (recursiveSolve(x, y - 1))
            { // Recalls method one up
                correctPath[x, y] = true;
                return true;
            }
        }
        if (y != mazeSquareSize - 1) // Checks if not on bottom edge
        {
            if (recursiveSolve(x, y + 1))
            { // Recalls method one down
                correctPath[x, y] = true;
                return true;
            }
        }
        return false;
    }
    	
	// Update is called once per frame
	void Update () {
	
	}
}