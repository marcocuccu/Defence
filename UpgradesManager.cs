using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradesManager : MonoBehaviour {

	public Text currentHealth;
	public Text currentDamage;
	public Text currentFirerate;
	public Text nextHealth;
	public Text nextDamage;
	public Text nextFirerate;
	public Text costHealth;
	public Text costDamage;
	public Text costFirerate;
	public Button upgradeFirerateButton;

	private AudioSource audioSource;

	void Start () 
	{
		updateValuesFromGameState ();
		audioSource = GameObject.FindGameObjectWithTag ("ClickSounds").GetComponent<AudioSource>();
	}

	// Upgrades logic.
	// If the player has enough money, change the money amount, upgrade the value and texts.
	public void upgradeHealth()
	{
		audioSource.Play();
		if(Game.gameState.goldCount - Game.gameState.upgradeMaxHealthCost >= 0)
		{
			Game.gameState.addGold(-Game.gameState.upgradeMaxHealthCost);
			Game.gameState.upgradeMaxHealth();
			updateValuesFromGameState ();
		}
	}
	public void upgradeDamage()
	{
		audioSource.Play();
		if(Game.gameState.goldCount - Game.gameState.upgradeDamageCost >= 0)
		{
			Game.gameState.addGold(-Game.gameState.upgradeDamageCost);
			Game.gameState.upgradeDamage();
			updateValuesFromGameState ();
		}
	}
	public void upgradeFirerate()
	{
		audioSource.Play();
		if(Game.gameState.goldCount - Game.gameState.upgradeFirerateCost >= 0)
		{
			Game.gameState.addGold(-Game.gameState.upgradeFirerateCost);
			Game.gameState.upgradeFirerate();
			updateValuesFromGameState ();
		}
	}

	// Refresh texts (values and costs) when the player buy an upgrade
	public void updateValuesFromGameState ()
	{
		currentHealth.text = "Health: " + Game.gameState.currentMaxHealth.ToString();
		nextHealth.text = "Health: " + (Game.gameState.currentMaxHealth + Game.gameState.upgradeMaxHealthEffect).ToString ();
		costHealth.text = "Cost: " + Game.gameState.upgradeMaxHealthCost.ToString();

		currentDamage.text = "Damage: " + Game.gameState.currentDamage.ToString();
		nextDamage.text = "Damage: " + (Game.gameState.currentDamage + Game.gameState.upgradeDamageEffect).ToString ();
		costDamage.text = "Cost: " + Game.gameState.upgradeDamageCost.ToString();

		currentFirerate.text = "Fire rate: " + Game.gameState.currentFirerate.ToString ();
		// We stop the firerate upgrade when it reach 0.26, otherwise is too powerful
		if (Game.gameState.currentFirerate > 0.26) {
			nextFirerate.text = "Fire rate: " + (Game.gameState.currentFirerate - Game.gameState.upgradeFirerateEffect).ToString ();
			costFirerate.text = "Cost: " + Game.gameState.upgradeFirerateCost.ToString ();
		} 
		else
		{
			nextFirerate.text = "MAX";
			upgradeFirerateButton.interactable = false;
		}

	}
	
	
	
	
	
	
	
	
	








}
