using UnityEngine;

/// <summary>
/// Manages the game over scene
/// </summary>
public class GameOver : MonoBehaviour {
    //Time length that the screen should be active
    public float screenDuration;
    //Time that the screen is active
    private float timeActive;
    //Check if the screen is active
    private bool isActive;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeActive = timeActive + Time.deltaTime;
            if (timeActive > screenDuration)
            {
                Debug.Log("Ended");
                DataTracking.resetGame();
            }
        }
    }

    /// <summary>
    /// Activates the end screen after minigame
    /// </summary>
    public void ActivateScreen()
    {
        gameObject.SetActive(true);
        isActive = true;
    }
}
