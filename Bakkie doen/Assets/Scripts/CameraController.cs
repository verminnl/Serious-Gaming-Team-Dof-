using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    public float moveSpeed;
    public bool isLevelCamera;
    private Vector3 targetPos;

    private static bool cameraExists;

	// Use this for initialization
	void Start () {
        if (!cameraExists && isLevelCamera)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        //print(isLevelCamera);

        if (!isLevelCamera)
        {
            Destroy(gameObject);
        }
	}
}
