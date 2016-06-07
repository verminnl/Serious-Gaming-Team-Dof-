using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    public float moveSpeed;
    public bool isLevelCamera;
    private Vector3 targetPos;

    private bool cameraExists;

	// Use this for initialization
	void Start () {
        followTarget = FindObjectOfType<PlayerController>().gameObject;
        if (!cameraExists && isLevelCamera)
        {
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(followTarget != null)
        {
            targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        if (!isLevelCamera)
        {
            Destroy(gameObject);
        }
	}
}
