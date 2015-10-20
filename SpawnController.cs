using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {
	
	public GameObject normalEnemy;
	public GameObject explosiveEnemy;
	public GameObject runnerEnemy;
	public GameObject smallEnemy;
	public GameObject strongEnemy;
	
	public float minTimeSpawn = 1;
	public float maxTimeSpawn = 5;
	public float timeBetweenWaves = 5;
	public int howManyWaves;
	public int enemiesPerWave;
	public Transform[] spawnPoints;
	
	private Transform randomSpawnPoint;
	private GameObject enemyToSpawn;
	private int randomValue;
	
	private int enemyIndex = 0;
	private int waveIndex = 0;
	
	private float timeToSpawn;
	public List<GameObject> enemies;
	public int spawnIndex = 0;
	
	// Use this for initialization
	void Start () 
	{
		timeToSpawn = Time.time + 1f;
		// All enemies are randomly created at the beggining and stored in an array, ready to be activate at the right moment
		instantiateEnemy ();
	}
	
	void Update()
	{
		spawnEnemy();
	}
	

	// Enemies are activated according with spawning times
	private void spawnEnemy()
	{
		// Spawn next enemy if timeToSpawn is passed and if we have other enemies to spawn
		if (Time.time > timeToSpawn && enemyIndex < enemiesPerWave && waveIndex < howManyWaves) 
		{
			enemyIndex++;
			enemies[spawnIndex++].SetActive(true);
			if(enemyIndex < enemiesPerWave) // If we have any enemy to spawn in this wave..
			{
				timeToSpawn = Time.time + Random.Range (minTimeSpawn, maxTimeSpawn);
			}
			else if(waveIndex < howManyWaves) // .. or we have other waves
			{
				timeToSpawn = Time.time + timeBetweenWaves;
				enemyIndex = 0;
				waveIndex++;
			}
		}
	}
	
	public void enemyEliminated(GameObject enemy)
	{
		enemies.Remove (enemy);
		spawnIndex--;
		if (enemies.Count == 0) 
		{
			Game.gameState.gameWon = true;
			Application.LoadLevel(4);
		}
	}
	
	// TODO: this function sucks
	public void instantiateEnemy()
	{
		int howManyEnemies = enemiesPerWave * howManyWaves; // Calculate how many enemies must spawn
		while (howManyEnemies > 0) {
			randomSpawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)]; // Choosing a random spawn point (they are about 8 for level)
			int level = Application.loadedLevel;
			randomValue = (int)Random.Range (0, 100); // This value is used for deciding what kind of enemy spawn

			if (level == 5) { // First level, just normal enemies
				enemyToSpawn = normalEnemy;
			}
			if (level == 6) { // Second level
				// If the random value is between 50 and 80, spawn a runnerEnemy, otherwise a normalEnemy
				if (randomValue >= 50 && randomValue < 80) 
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 7) {
				if (randomValue >= 50 && randomValue < 80)
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 8) {
				if (randomValue >= 50 && randomValue < 90)
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 9) {
				if (randomValue >= 50 && randomValue < 90)
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 10) {
				if (randomValue >= 50 && randomValue < 100)
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 11) {
				if (randomValue >= 50 && randomValue < 80)
					enemyToSpawn = runnerEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 12) {
				if (randomValue >= 50 && randomValue < 70)
					enemyToSpawn = runnerEnemy;
				else if (randomValue >= 80 && randomValue < 90)
					enemyToSpawn = strongEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 13) {
				if (randomValue >= 50 && randomValue < 70)
					enemyToSpawn = runnerEnemy;
				else if (randomValue >= 80 && randomValue < 90)
					enemyToSpawn = strongEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			if (level == 14) {
				if (randomValue >= 50 && randomValue < 70)
					enemyToSpawn = runnerEnemy;
				else if (randomValue >= 80 && randomValue < 100)
					enemyToSpawn = strongEnemy;
				else
					enemyToSpawn = normalEnemy;
			}
			enemies.Add ((GameObject)Instantiate (enemyToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation));
			enemies[enemies.Count-1].SetActive(false);
			howManyEnemies--;
		}
			

	}
	
}