using UnityEngine;

public class BluePlayerStartPoint : MonoBehaviour {

    private BlueMinigamePlayerController thePlayer;

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<BlueMinigamePlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
