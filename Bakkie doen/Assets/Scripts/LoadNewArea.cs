using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    public string levelToLoad;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && PlayerController.actionButtonPressed)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && PlayerController.actionButtonPressed)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
