using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// This file is a small DB storing all the informations needed when you run the game or when scene change.
[System.Serializable]
public class GameState {
	
	public bool gameWon;
	public int goldCount;
	public int playerActualHealth;
	public int lastLevelPlayed;
	public int lastLevelAvailable;
	public bool musicActive;
	public bool soundsActive;
	
	// Upgrades
	public int currentMaxHealth;
	public int upgradeMaxHealthCost;
	public int upgradeMaxHealthEffect;
	
	public int currentDamage;
	public int upgradeDamageCost;
	public int upgradeDamageEffect;
	
	public double currentFirerate;
	public int upgradeFirerateCost;
	public double upgradeFirerateEffect;

	public float invertHorizontal;
	public float invertVertical;

	
	public GameState()
	{
		gameWon = false;
		goldCount = 0;
		lastLevelPlayed = 5;
		lastLevelAvailable = 5;
		currentMaxHealth = 100;
		upgradeMaxHealthCost = 100;
		upgradeMaxHealthEffect = 10;
		currentDamage = 25;
		upgradeDamageCost = 100;
		upgradeDamageEffect = 5;
		currentFirerate = 1; 
		upgradeFirerateCost = 100;
		upgradeFirerateEffect = 0.15;
		playerActualHealth = currentMaxHealth;
		invertHorizontal = 1f;
		invertVertical = -1f;
		musicActive = true;
		soundsActive = true;
	}
	
	// ------------------ Methods ----------------------

	public void addGold(int amount)
	{
		goldCount += amount;
		if (goldCount < 0) 
		{
			goldCount = 0;
		}
	}

	public void resetHealth()
	{
		playerActualHealth = currentMaxHealth;
	}

	public void upgradeMaxHealth()
	{
		currentMaxHealth += upgradeMaxHealthEffect;
		upgradeMaxHealthCost += 100;
	}

	public void upgradeDamage()
	{
		currentDamage += upgradeDamageEffect;
		upgradeDamageCost += 200;
	}

	public void upgradeFirerate()
	{
		currentFirerate -= upgradeFirerateEffect;
		upgradeFirerateCost += 200;
	}

	public void changeActualHealth(int amount)
	{
		playerActualHealth += amount;
	}

}

// We save the object gameState as static so it can be accessed from everywhere.
public static class Game 
{
	public static GameState gameState = SaveLoad.Load();
}

