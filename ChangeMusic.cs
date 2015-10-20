using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip gameplayMusic;

	private AudioSource source;
	private int firstLevel = 5; // This is the scene number of the first level

	void Awake () 
	{
		source = GetComponent<AudioSource> ();
		source.clip = menuMusic;
		source.Play ();
	}

	// 
	void OnLevelWasLoaded (int scene) 
	{
		if (scene >= firstLevel && source.clip.name == menuMusic.name) {
			source.clip = gameplayMusic;
			source.Play ();
		}

		else if (scene < firstLevel && source.clip.name == gameplayMusic.name)
		{
			source.clip = menuMusic;
			source.Play ();
		}
	}
}
