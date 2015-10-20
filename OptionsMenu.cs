using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Text invertHorizontalText;
	public Text invertVerticalText;

	public Text musicActiveText;
	public Text effectActiveText;

	private AudioSource musicAudioSource;
	private AudioSource clickAudioSource;
	private AudioSource shootAudioSource;

	void Start () {
		musicAudioSource = GameObject.FindGameObjectWithTag ("BackgroundMusic").GetComponent<AudioSource> ();
		clickAudioSource = GameObject.FindGameObjectWithTag ("ClickSounds").GetComponent<AudioSource> ();
		shootAudioSource = GameObject.FindGameObjectWithTag ("ShootSound").GetComponent<AudioSource> ();
		Time.timeScale = 1;
	}

	void Update () {
		if(gameObject.activeSelf)
			Time.timeScale = 0;	// Pause the game when options screen is active
	}

	// Play/stop music
	public void music()
	{
		if (Game.gameState.musicActive) 
		{
			musicAudioSource.volume = 0;
			Game.gameState.musicActive = false;
		}
		else
		{
			musicAudioSource.volume = 1;
			Game.gameState.musicActive = true;
		}
		musicActiveText.text = "Music: " + (Game.gameState.musicActive ? "On" : "Off");
	}

	// Play/stop effects
	public void effects()
	{
		if (Game.gameState.soundsActive) 
		{
			clickAudioSource.volume = 0;
			shootAudioSource.volume = 0;
			Game.gameState.soundsActive = false;
		}
		else
		{
			clickAudioSource.volume = 1;
			shootAudioSource.volume = 1;
			Game.gameState.soundsActive = true;
		}
		effectActiveText.text = "Effects: " + (Game.gameState.soundsActive ? "On" : "Off");
	}

	public void restart()
	{
		Time.timeScale = 1;
		gameObject.SetActive (false);
		Application.LoadLevel (Application.loadedLevel);
	}

	public void resume()
	{
		Time.timeScale = 1;
		gameObject.SetActive (false);
	}

	public void mainMenu()
	{
		Time.timeScale = 1;
		gameObject.SetActive (false);
		Application.LoadLevel (1);
	}

	public void invertHorizontal()
	{
		Game.gameState.invertHorizontal *= -1;
		invertHorizontalText.text = "Invert horizontal: " + (Game.gameState.invertHorizontal == 1 ? "off" : "on");
	}

	public void invertVertical()
	{
		Game.gameState.invertVertical *= -1;
		invertVerticalText.text = "Invert vertical: " + (Game.gameState.invertVertical == 1 ? "off" : "on");
	}
}
