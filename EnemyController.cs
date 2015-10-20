using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Transform player;
	private NavMeshAgent nav;
	private float attackTime;
	private GameObject spawnController;
	private float distance;

	public int damage = 50;
	public float attackRepeatTime = 3.0f;
	private float attackRange = 2.7f;
	public int health = 2;
	public int gold = 10;
	private bool hit = false;

	public AudioClip[] enemySounds;
	public AudioClip deadClip;
	private AudioSource audioSource;
	private Animator animator;

	private float knockbackDuration = 0.3f;
	private float knockbackCountDown;
	private float normalSpeed;


	void Awake () 
	{
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = transform.parent.GetComponent<NavMeshAgent> ();	
		attackTime = Time.time;
		normalSpeed = nav.speed;
	}

	void Update () 
	{
		// We set the enemy target 
		// (player.position - transform.position).normalized * 2.5f) is needed because the target is not a point, but a circle
		nav.SetDestination (player.position - (player.position - transform.position).normalized * 2.5f);

		// I used this flag because of some synchronization problems
		if (hit) 
		{
			applyDamage ();
			hit = false;
		}

		// The enemy stops a moment when is hit, then runs to the player
		if (knockbackCountDown > 0)
		{
			nav.speed = 0;
			knockbackCountDown -= Time.deltaTime;
		}
		else
		{
			nav.speed = normalSpeed;
		}

		// The enemy attacks if he is close to the player
		distance = Vector3.Distance (player.position, transform.position);
		if(distance < attackRange)
		{
			attack();
		}
	}

	void attack()
	{
		if (Time.time > attackTime)
		{
			player.SendMessage("applyDamage", damage, SendMessageOptions.DontRequireReceiver);
			attackTime = Time.time + attackRepeatTime;
		}
	}

	// This method is called when a bullet hit this enemy
	public void bulletHitEnemy()
	{
		hit = true;
		knockbackCountDown = knockbackDuration;
	}


	public void applyDamage()
	{
		health -= Game.gameState.currentDamage;
		if (health <= 0) 
		{
			if(Game.gameState.soundsActive)
			{
				audioSource.Stop ();
				audioSource.clip = deadClip;
				audioSource.Play ();
			}

			animator.SetBool("Dead", true);
		}
		else if(Game.gameState.soundsActive)
		{
			audioSource.Stop ();
			audioSource.clip = enemySounds [Random.Range (0, enemySounds.Length)]; // Play a random sound from the array "enemySounds"
			audioSource.Play ();
		}
	}
	
	private void dead()
	{
		// Alert the controller that this enemy is dead
		spawnController = GameObject.FindGameObjectWithTag("SpawnController");
		spawnController.transform.SendMessage("enemyEliminated", transform.parent.gameObject, SendMessageOptions.DontRequireReceiver);
		Destroy(transform.parent.gameObject);
		Game.gameState.addGold (gold);
	}

}


