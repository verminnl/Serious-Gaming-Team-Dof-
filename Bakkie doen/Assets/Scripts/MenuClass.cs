using UnityEngine;
using System.Collections;
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
    public bool isActive;
    public PlayerController player;
    private int selector;

    // Use this for initialization
    void Start () {
        //Default selected option.
        selectedOption = optionRed;
        previousSelectedOption = optionRed;
        toggleActive(false);
        selector = 0;


        player = FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selector++;
                if (selector > 3)
                {
                    selector = 0;
                }
                selectedOptionSetter(selector);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selector--;
                if (selector < 0)
                {
                    selector = 3;
                }
                selectedOptionSetter(selector);
            }

            if (selectedOption != previousSelectedOption)
            {
                selectedOption.GetComponent<Text>().color = Color.blue;
                previousSelectedOption.GetComponent<Text>().color = Color.white;
                previousSelectedOption = selectedOption;
            }

            if (Input.GetKeyDown(KeyCode.Return))
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
                player.canMove = true;
                isActive = false;
                player.startPoint = startPoint;
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
