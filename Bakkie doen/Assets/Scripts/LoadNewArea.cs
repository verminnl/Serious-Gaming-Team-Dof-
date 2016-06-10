using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads a Unity scene
/// </summary>
public class LoadNewArea : MonoBehaviour {
    //Name of the Unity scene that the game should load
    public string levelToLoad;
    //Name of the point where the player will be spawned at, in the new Unity scene
    public string exitPoint;
    //Player of the game
    private PlayerController thePlayer;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }
    
    /// <summary>
    /// Activates when this gameobject collides with another gameobject
    /// </summary>
    /// <param name="other">The gameobject that this gameobject collides with</param>
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            DataTracking.previousFloor = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
