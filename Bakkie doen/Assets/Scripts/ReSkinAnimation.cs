using UnityEngine;
using System;

/// <summary>
/// Re-skins a character with a given spritesheet
/// https://www.youtube.com/watch?v=rMCLWt1DuqI <--------Info about this script
/// </summary>
public class ReSkinAnimation : MonoBehaviour {
    //Name of the sprite
	public string spriteSheetName;

    //LateUpdate is called after all Update functions have been called
	void LateUpdate () {
        //Subs the sprite of the character, the sprites must have the same name
		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
            
			var newSprite = Array.Find(DataTracking.playerData.CharacterSprite, item => item.name == spriteName);
            
			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
