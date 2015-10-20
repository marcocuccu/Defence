using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Exit the game when the key "escape" is pressed
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
}
