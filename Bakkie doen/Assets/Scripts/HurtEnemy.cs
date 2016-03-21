using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
