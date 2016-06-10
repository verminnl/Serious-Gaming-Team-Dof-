using UnityEngine;

/// <summary>
/// Controls the behaviour of the camera
/// </summary>
public class CameraController : MonoBehaviour {
    //Gameobject that the current camera should follow
    public GameObject followTarget;
    //Movement speed of the camera
    public float moveSpeed;
    //Checks if the camera is in 1 of the 4 areas
    public bool isLevelCamera;
    //Position of the gameobject that the camera should be following
    private Vector3 targetPos;
    //Checks if the camera exists
    private bool cameraExists;

	// Use this for initialization
	void Start () {
        //Makes sure that there is only one camera in an area
        if (!cameraExists && isLevelCamera)
        {
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate () {
        //Makes the camera follow its target
        if (followTarget != null)
        {
            targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        //Destroys this camera when a minigame activates
        if (!isLevelCamera)
        {
            Destroy(gameObject);
        }
	}
}
