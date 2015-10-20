using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	private AudioSource audioSource;

	public GameObject loadingImage;
	private int firstLevel = 5;
	private int lastLevel = 14;

	void Start()
	{
		audioSource = GameObject.FindGameObjectWithTag ("ClickSounds").GetComponent<AudioSource>();
	}

	public void LoadScene(int scene)
	{
		SaveLoad.Save ();
		audioSource.Play();
		// If we are loading a gameplay scene, active the loading image and manage the loading bar
		if (scene >= firstLevel && scene < lastLevel) 
		{
			loadingImage.SetActive (true);
		}

		Application.LoadLevel (scene);
	}

	public void retry()
	{
		LoadScene (Game.gameState.lastLevelPlayed);
	}

	public void next()
	{
		if(Application.loadedLevel < lastLevel)
			LoadScene (Game.gameState.lastLevelPlayed + 1);
	}
}
