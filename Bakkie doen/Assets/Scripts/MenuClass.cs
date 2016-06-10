using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuClass : MonoBehaviour {

    public GameObject selectedOption;
    private GameObject previousSelectedOption;
    public GameObject optionRed;
    public GameObject optionBlue;
    public GameObject optionGreen;
    public GameObject optionYellow;
    public GameObject elevator_Canvas;
    public GameController gameController;
    public bool isActive;
    public PlayerController player;
    private int selector;
    private int frameCount;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();

        //Default selected option.
        selectedOption = optionRed;
        previousSelectedOption = optionRed;
        selectedOption.GetComponent<Text>().color = Color.blue;
        toggleActive(false);
        selector = 0;
        frameCount = 0;
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if(frameCount != 10)
        {
            frameCount++;
        }
        if (isActive)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && frameCount == 10)
            {
                frameCount = 0;
                selector--;
                if (selector < 0)
                {
                    selector = 3;
                }
                selectedOptionSetter(selector);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && frameCount == 10)
            {
                frameCount = 0;
                selector++;
                if (selector > 3)
                {
                    selector = 0;
                }
                selectedOptionSetter(selector);
            }

            if (selectedOption != previousSelectedOption)
            {
                selectedOption.GetComponent<Text>().color = Color.blue;
                previousSelectedOption.GetComponent<Text>().color = Color.white;
                previousSelectedOption = selectedOption;
            }

            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            {
                string destination = "";
                string startPoint = "";
                switch (selectedOption.tag)
                {
                    case "Elevator_Red":
                        destination = "T0";
                        startPoint = "Elevator_Red";
                        break;
                    case "Elevator_Green":
                        destination = "T2";
                        startPoint = "Elevator_Green";
                        break;
                    case "Elevator_Blue":
                        destination = "T1";
                        startPoint = "Elevator_Blue";
                        break;
                    case "Elevator_Yellow":
                        destination = "T3";
                        startPoint = "Elevator_Yellow";
                        break;
                }
                gameController.inElevator = false;
                DataTracking.previousFloor = startPoint;
                SceneManager.LoadScene(destination);
            }
        }
    }

    public void toggleActive(bool active)
    {
        elevator_Canvas.SetActive(active);
    }

    public void selectedOptionSetter(int selector)
    {
        switch (selector)
        {
            case 0:
                selectedOption = optionRed;
                break;
            case 1:
                selectedOption = optionBlue;
                break;
            case 2:
                selectedOption = optionGreen;
                break;
            case 3:
                selectedOption = optionYellow;
                break;
        }
    }
}