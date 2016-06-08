using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public PlayerController player;
    public MenuClass elevator;
    public GameController gameController;


    // Use this for initialization
    void Start () {
        elevator.isActive = false;
        player = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update ()
    {
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!elevator.isActive)
        {
            elevator.isActive = true;
            gameController.inElevator = true;
            elevator.toggleActive(true);
            if (elevator.isActive)
            {
                player.canMove = false;
            }
        }
    }
}