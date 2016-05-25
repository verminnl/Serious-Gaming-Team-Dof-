using UnityEngine;

/// <summary>
/// Gives damage to an object if this gameobject touches it
/// </summary>
public class GiveDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Activates when this gameobject touches another object with a triggerbox
    /// </summary>
    /// <param name="other">The object that this gameobject touches</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject); //Destroy the enemy
            gameObject.SetActive(false); //Destroy the bullet
        }
    }

    // OnBecameInvisible is called when the renderer is no longer visible by any camera
    public void OnBecameInvisible()
    {
        //When gameobject is no longer visible by the camera, sets it to the inactive state
        gameObject.SetActive(false);
    }

    
}
