using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingTransition : MonoBehaviour {

    //public GameObject theLoadingScreen;
    public Image theLoadingImage;
    public float imageRotateSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        theLoadingImage.rectTransform.Rotate(new Vector3(0, imageRotateSpeed * Time.deltaTime, 0));
	}
}
