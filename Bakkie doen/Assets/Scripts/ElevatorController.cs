using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

    public PlayerController player;
    public MenuClass elevator;

	// Use this for initialization
	void Start () {
        elevator.isActive = false;
        player = FindObjectOfType<PlayerController>();
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
            elevator.toggleActive(true);
            if (elevator.isActive)
            {
                player.canMove = false;
            }
        }
    }
}