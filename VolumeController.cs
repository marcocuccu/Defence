using UnityEngine;
using System.Collections;

public class VolumeController : MonoBehaviour {

	public GameObject backgroundMusic;
	public GameObject clickSounds;
	public GameObject shootSound;

	// Able or disable sounds
	void Start () {
		backgroundMusic.GetComponent<AudioSource>().volume = Game.gameState.musicActive ? 1 : 0;
		clickSounds.GetComponent<AudioSource>().volume = Game.gameState.soundsActive ? 1 : 0;
		shootSound.GetComponent<AudioSource>().volume = Game.gameState.soundsActive ? 1 : 0;
	}
}
