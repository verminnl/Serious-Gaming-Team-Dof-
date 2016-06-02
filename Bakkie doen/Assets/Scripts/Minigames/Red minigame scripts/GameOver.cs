using UnityEngine;

/// <summary>
/// Manages the game over scene
/// </summary>
public class GameOver : MonoBehaviour {
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BackEndCommunicator.Instance.EndGameSave(DataTracking.playerData.PlayerID, 0, DataTracking.playerData.SessionID, DataTracking.playerData.SpawnPoint, DataTracking.playerData.Tutorial);
                
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