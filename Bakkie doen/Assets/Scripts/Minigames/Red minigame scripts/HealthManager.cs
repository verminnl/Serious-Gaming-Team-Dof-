﻿using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public Image[] health;
    public Sprite emptyHealth;
    private int totalHealth;
    private RedMinigamePlayerController thePlayer;

	// Use this for initialization
	void Start () {
        totalHealth = health.Length;
        thePlayer = FindObjectOfType<RedMinigamePlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (totalHealth <= 0)
        {
            //Destroy(thePlayer.GetComponent<Collider2D>());
            RedMinigamePlayerController.isAlive = false;
        }
	}

    public void TakeDamage()
    {
        if(totalHealth == 0)
        {
            return;
        }
        health[totalHealth - 1].sprite = emptyHealth;
        totalHealth--;
    }
}
