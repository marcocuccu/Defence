using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowHealth : MonoBehaviour {
	
	public Slider slider; // Player life is shown as slider bar
	
	public Image damageImage;
	private float actualLife;
	private bool takeDamage = false;

	private Color damageColor = new Color (1f, 0f, 0f, 0.7f);
	private float flashSpeed = 60f;

	void Start () 
	{
		slider.maxValue = Game.gameState.currentMaxHealth;
		actualLife = Game.gameState.currentMaxHealth;
	}

	void Update()
	{
		slider.value = Game.gameState.playerActualHealth;

		if (takeDamage) 
		{
			// The camera flashes red when player take damage
			damageImage.color = Color.Lerp(damageImage.color, Color.clear,flashSpeed * Time.deltaTime);
			takeDamage = false;
		}

		if (actualLife != slider.value) 
		{
			actualLife = slider.value;
			damageImage.color = damageColor;
			takeDamage = true;
		}

	}
}
