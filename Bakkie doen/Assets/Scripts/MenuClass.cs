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

    // Use this for initialization
    void Start () {
        //Default selected option.
        selectedOption = optionRed;
        previousSelectedOption = optionRed;
        toggleActive(false);

        player = FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {    
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(selectedOption == optionRed)
            {
                selectedOption = optionYellow;
            }
            else if(selectedOption == optionBlue)
            {
                selectedOption = optionRed;
            }
            else if(selectedOption == optionGreen)
            {
                selectedOption = optionBlue;
            }
            else
            {
                selectedOption = optionGreen;
            }
            print(selectedOption);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedOption == optionRed)
            {
                selectedOption = optionBlue;
            }
            else if (selectedOption == optionBlue)
            {
                selectedOption = optionGreen;
            }
            else if (selectedOption == optionGreen)
            {
                selectedOption = optionYellow;
            }
            else
            {
                selectedOption = optionRed;
            }
            print(selectedOption);
        }

        if (selectedOption != previousSelectedOption)
        {
            selectedOption.GetComponent<Text>().color = Color.blue;
            previousSelectedOption.GetComponent<Text>().color = Color.white;
            previousSelectedOption = selectedOption;
        }

        if (Input.GetKeyDown(KeyCode.Return) && isActive)
        {
            string destination = "";
            switch (selectedOption.tag)
            {
                case "Elevator_Red":
                    destination = "T0";
                    break;
                case "Elevator_Green":
                    destination = "T2";
                    break;
                case "Elevator_Blue":
                    destination = "T1";
                    break;
                case "Elevator_Yellow":
                    destination = "T3";
                    break;
            }
            print("FUCK YOU");
            print("klootzak kan weer lopen");
            player.canMove = true;
            print("kutscherm inactief");
            isActive = false;
            print("kutscene laden");
            SceneManager.LoadScene(destination);
        }
    }

    public void toggleActive(bool active)
    {
        elevator_Canvas.SetActive(active);
    }
}
