using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the elevator options
/// </summary>
public class MenuClass : MonoBehaviour {
    //Current selected option
    public GameObject selectedOption;
    //Previously selected option
    private GameObject previousSelectedOption;
    //Red area option
    public GameObject optionRed;
    //Blue area option
    public GameObject optionBlue;
    //Green area option
    public GameObject optionGreen;
    //Yellow area option
    public GameObject optionYellow;
    //Canvas with the elevator menu
    public GameObject elevator_Canvas;
    //Game controller of the game
    public GameController gameController;
    //Checks if the elevator menu is active
    public bool isActive;
    //Player of the game
    public PlayerController player;
    //Keeps track of the selected option
    private int selector;


    // Use this for initialization
    void Start () {
        //Default selected option.
        gameController = FindObjectOfType<GameController>();
        selectedOption = optionRed;
        previousSelectedOption = optionRed;
        selectedOption.GetComponent<Text>().color = Color.blue;
        toggleActive(false);
        selector = 0;
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            //Controls the selection in the elevator menu
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selector--;
                if (selector < 0)
                {
                    selector = 3;
                }
                selectedOptionSetter(selector);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selector++;
                if (selector > 3)
                {
                    selector = 0;
                }
                selectedOptionSetter(selector);
            }

            //Controls the color of the selected option
            if (selectedOption != previousSelectedOption)
            {
                selectedOption.GetComponent<Text>().color = Color.blue;
                previousSelectedOption.GetComponent<Text>().color = Color.white;
                previousSelectedOption = selectedOption;
            }

            //Loads a Unity scene based on the selected option after pressing the {Enter key or keypadenter}
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

    /// <summary>
    /// Toggles the canvas with the elevator menu on or off
    /// </summary>
    /// <param name="active">Decides if the canvas should be active or not</param>
    public void toggleActive(bool active)
    {
        elevator_Canvas.SetActive(active);
    }

    /// <summary>
    /// Decides which selection is selected at the moment
    /// </summary>
    /// <param name="selector">The option that is being selected</param>
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