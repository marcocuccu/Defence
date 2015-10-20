using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowGold : MonoBehaviour {
	
	public Text text;

	// Update the gold text
	void Update()
	{
		text.text = "Gold: " + Game.gameState.goldCount.ToString();
	}
}
