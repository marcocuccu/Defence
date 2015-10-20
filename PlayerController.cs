using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	private Transform transorm;
	private GameObject bulletTemp;

	private AudioSource audioSource;

	public bool limitedRotation = false;
	private float bulletSpeed = 1600;
	public GameObject bullet;
	public Transform bulletSpawn;
	public Transform cameraMap;
	private float timeToShoot;

	// --------------------- Aim
	//Mouse rotation input
	private float rotationX = 0;
	private float rotationY = 0;
	
	//Mouse look sensitivity
	public float sensitivityX = 1.2f;
	public float sensitivityY = 1f;

	public float deltaX;
	public float deltaY;
	private float rotationFunctionX;
	private float rotationFunctionY;
	public float rangeFunctionX = 4f;
	public float rangeFunctionY = 4f;


	void Start()
	{
		audioSource = GameObject.FindGameObjectWithTag("ShootSound").GetComponent<AudioSource> ();

		Game.gameState.lastLevelPlayed = Application.loadedLevel;
		transorm = GetComponent<Transform> ();
		timeToShoot = Time.time;


		if (GetComponent<Rigidbody>()) 
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	void Update()
	{
		foreach(Touch touch in Input.touches)
		{
			deltaX = touch.deltaPosition.x;
			deltaY = touch.deltaPosition.y;

			// Quadratic function with the value of 1 shifted by a certain range

			// If the delta movement on X axis has a value between -range and range, divide the delta by range and make a quadratic function
			if(deltaX>-rangeFunctionX && deltaX<=0)
				rotationFunctionX = -((deltaX/rangeFunctionX)*(deltaX/rangeFunctionX));
			else if(deltaX>0 && deltaX<rangeFunctionX)
				rotationFunctionX = ((deltaX/rangeFunctionX)*(deltaX/rangeFunctionX));
			// Linear function for delta values out of the smaller than -range or bigger than range
			else
			{
				if(deltaX < 0)
				{
					rotationFunctionX = (deltaX + rangeFunctionX) * sensitivityX;
				}
				else
				{
					rotationFunctionX = (deltaX - rangeFunctionX) * sensitivityX;
				}
			}


			if(deltaY>-rangeFunctionY && deltaY<=0)
				rotationFunctionY = -((deltaY/rangeFunctionY)*(deltaY/rangeFunctionY));
			else if(deltaY>0 && deltaY<rangeFunctionY)
				rotationFunctionY = ((deltaY/rangeFunctionY)*(deltaY/rangeFunctionY));
			else
			{
				if(deltaY < 0)
				{
					rotationFunctionY = (deltaY + rangeFunctionY) * sensitivityY;
				}
				else
				{
					rotationFunctionY = (deltaY - rangeFunctionY) * sensitivityY;
				}
			}

			// Invert axis if required
			rotationX += rotationFunctionX * Game.gameState.invertHorizontal;
			rotationY += rotationFunctionY * Game.gameState.invertVertical;

			// Avoiding backflips and frontflips
			if (rotationY < -30) rotationY = -30;
			if (rotationY > 70) rotationY = 70;
			if (rotationX < -90 && limitedRotation) rotationX = -90;
			if (rotationX > 90 && limitedRotation) rotationX = 90;


			// Setting the cameraMap rotation according with the player rotation
			if(!limitedRotation)
			{
				cameraMap.eulerAngles = new Vector3(90, rotationX + 180, 0.0f);
			}

			transorm.eulerAngles = new Vector3 (rotationY, rotationX, 0);
		}
		shoot();
	}

	// Shoot bullets after been waiting for timeToShoot time
	void shoot()
	{
		if(Time.time > timeToShoot)
		{
			bulletTemp = (GameObject)Instantiate (bullet, bulletSpawn.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));
			bulletTemp.GetComponent<Rigidbody> ().velocity = bulletSpawn.forward * bulletSpeed * Time.deltaTime;
			timeToShoot = Time.time + (float)Game.gameState.currentFirerate;
			audioSource.Play();
		}
	}
}


