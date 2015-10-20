using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButtonsInteraction : MonoBehaviour {
	
	public Button[] buttons;
	
	void Start()
	{
		// Activing the available levels. The "-4" is because the first scenes are not levels.
		for(int i = Game.gameState.lastLevelAvailable - 4; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
		}
	}
}
