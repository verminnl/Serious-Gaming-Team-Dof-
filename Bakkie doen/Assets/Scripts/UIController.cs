using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIController : MonoBehaviour {
    //The area box in the game
    public Text areaBoxText;
    //Checks if the areaBox exists
    private static bool areaBoxExists;

    // Use this for initialization
    void Start()
    {
        //areaBoxText.text = SceneManager.GetActiveScene().name;

        //if (!areaBoxExists)
        //{
        //    areaBoxExists = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
