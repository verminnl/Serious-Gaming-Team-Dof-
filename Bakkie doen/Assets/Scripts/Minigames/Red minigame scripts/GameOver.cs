using UnityEngine;

/// <summary>
/// Manages the game over scene
/// </summary>
public class GameOver : MonoBehaviour {
    //Check if the screen is active
    private bool isActive;

    // Update is called once per frame
    void Update()
    {
        //When the player presses the {Enter key or keypadenter} when this gameobject is active, ends the current game session
        if (isActive)
        {
            if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
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