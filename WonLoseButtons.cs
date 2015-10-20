using UnityEngine;
using System.Collections;

public class WonLoseButtons : MonoBehaviour {

	public GameObject nextButton;
	public GameObject retryButton;

	void Start () 
	{
		// If the player win the level, unlock the next level and the button "next" will appear
		if (Game.gameState.gameWon) 
		{
			if(Game.gameState.lastLevelPlayed == Game.gameState.lastLevelAvailable)
			{
				Game.gameState.lastLevelAvailable++;
			}
			nextButton.SetActive(true);
			retryButton.SetActive(false);
		}
		else 
		{
			nextButton.SetActive(false);
			retryButton.SetActive(true);
		}
	}
}
