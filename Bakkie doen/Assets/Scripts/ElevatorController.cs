using UnityEngine;

/// <summary>
/// Controls the behaviour of the elevator
/// </summary>
public class ElevatorController : MonoBehaviour {
    //Player of the game
    public PlayerController player;
    //Elevator of the game
    public MenuClass elevator;
    //Game controller of the game
    public GameController gameController;

    // Use this for initialization
    void Start () {
        elevator.isActive = false;
        player = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
    }
    
    /// <summary>
    /// Activates when this gameobject collides with another gameobject
    /// </summary>
    /// <param name="other">The gameobject that this gameobject collides with</param>
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