using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	void Start()
	{
		// Set the health player at its max value
		Game.gameState.resetHealth();
	}


	public void applyDamage(int damage)
	{
		Game.gameState.changeActualHealth (-damage);

		// If the player die, load the game over scene
		if (Game.gameState.playerActualHealth <= 0) 
		{
			Game.gameState.gameWon = false;
			Application.LoadLevel (4);
		}
	}
}
