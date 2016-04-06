using UnityEngine;
using System.Collections;

public class NarratorController : MonoBehaviour {

    public string[] dialogue;

    public NarratorClass narrator;

    void Awake()
    {
        narrator = new NarratorClass(gameObject.name, dialogue);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
