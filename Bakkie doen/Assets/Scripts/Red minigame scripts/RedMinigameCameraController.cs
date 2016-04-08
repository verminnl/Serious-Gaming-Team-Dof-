using UnityEngine;
using System.Collections;

public class RedMinigameCameraController : MonoBehaviour {

    public GameObject followTarget;
    public float moveSpeed;
    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(transform.position.x, followTarget.transform.position.y + 8, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
