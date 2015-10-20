using UnityEngine;
using System.Collections;

public class OptionsShow : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject mainMenuButton;
	public GameObject restartButton;

	// Customize the options menu depending from where is called: if it is called from gameplay buttons mainMenu and restart will be shown
	public void options(bool isInGameplay)
	{
		optionsMenu.SetActive(true);
		if (isInGameplay) 
		{
			mainMenuButton.SetActive(true);
			restartButton.SetActive(true);
		} else 
		{
			mainMenuButton.SetActive(false);
			restartButton.SetActive(false);
		}
	}
}
