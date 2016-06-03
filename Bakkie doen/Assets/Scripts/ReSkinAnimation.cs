using UnityEngine;
using System;

/// <summary>
/// Example code of how to re skin a character
/// </summary>
public class ReSkinAnimation : MonoBehaviour {

	public string spriteSheetName;

	void LateUpdate () {

		//var subSprites = Resources.LoadAll<Sprite>("Characters/" + DataTracking.playerData.Character);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			string spriteName = renderer.sprite.name;
            
			var newSprite = Array.Find(DataTracking.playerData.CharacterSprite, item => item.name == spriteName);
            
			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
