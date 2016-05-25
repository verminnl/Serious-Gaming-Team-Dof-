﻿using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;        // The texture that will overlay the screen. This can be a black image or a loading graphic
    public float fadeSpeed;                 // The fading speed

    private int drawDepth = -1000;          // The texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f;             // The texture's alpha value between 0 and 1
    private int fadeDir = -1;               // The direction to fade: in = -1 or out = 1

    void OnGUI()
    {
        // Fade out/in the alpha value using the direction, a speed and Time.deltaTime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Force (clamp) the number between 0 and 1 because GUI.Color uses alpha values between 0 and 1;
        alpha = Mathf.Clamp01(alpha);

        // Set color of our GUI (in this case our texture). All color values remain the same & the alpha value is set to the alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);            // Set the alpha value
        GUI.depth = drawDepth;                                                          // Make the black texture renders on top (drawn last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   // Draw the texture to fit the entire screen area
    }

    // Sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);     // Return the fadeSpeed variable so it's easy to time the SceneManager.LoadScene();
    }

    // OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
    void OnLevelWasLoaded()
    {
        // alpha = 1;       // Use this if the alpha is not set to 1 by default
        BeginFade(-1);      // Call the fade in function
    }
}
