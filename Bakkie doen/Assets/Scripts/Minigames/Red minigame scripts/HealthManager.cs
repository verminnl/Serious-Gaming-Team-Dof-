using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the health of the player in the red minigame
/// </summary>
public class HealthManager : MonoBehaviour {
    //Sprite images for each of the life that the player has
    public Image[] health;
    //Sprite that appears in the place of a lost life
    public Sprite emptyHealth;
    //Total health that the player has
    private int totalHealth;
    //Player in the red minigame
    private RedMinigamePlayerController thePlayer;

	// Use this for initialization
	void Start () {
        totalHealth = health.Length;
        thePlayer = FindObjectOfType<RedMinigamePlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Sets the player to the "Death"-state when his/her life becomes 0
        if (totalHealth <= 0)
        {
            RedMinigamePlayerController.isAlive = false;
        }
	}

    /// <summary>
    /// Depletes a life from the health of the player
    /// </summary>
    public void TakeDamage()
    {
        if(totalHealth == 0)
        {
            return;
        }
        health[totalHealth - 1].sprite = emptyHealth;
        totalHealth--;
    }
}
