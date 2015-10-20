using UnityEngine;
using System.Collections;

// When we press the zoom button, we change the zoomIn bool value. It means set different camera values, in order to zoom in or zoom out.
public class ZoomLogic : MonoBehaviour {

	public Camera camera;
	public GameObject player;
	private PlayerController playerController;

	private bool zoomIn = false;
	private float defaultFOV;
	public float zoomSpeed;
	public float zoomInFOV;
	public float defaultRangeFunctionX;
	public float defaultRangeFunctionY;
	public float defaultSensitivityX;
	public float defaultSensitivityY;

	public void Start()
	{
		defaultFOV = camera.fieldOfView;
		zoomSpeed = 9 * Time.deltaTime;
		zoomInFOV = 30;
		playerController = player.GetComponent<PlayerController> ();
		defaultRangeFunctionX = playerController.rangeFunctionX;
		defaultRangeFunctionY = playerController.rangeFunctionY;
		defaultSensitivityX = playerController.sensitivityX;
		defaultSensitivityY = playerController.sensitivityY;
	}

	public void zoomButtonPressed ()
	{
		zoomIn = !zoomIn;
	}


	public void Update()
	{
		if (zoomIn) 
		{
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, zoomInFOV, zoomSpeed);
			playerController.rangeFunctionX = 8f;
			playerController.rangeFunctionY = 10f;
			playerController.sensitivityX = 0.1f;
			playerController.sensitivityY = 0.06f;
		} 
		else 
		{
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, defaultFOV, zoomSpeed);
			playerController.rangeFunctionX = defaultRangeFunctionX;
			playerController.rangeFunctionY = defaultRangeFunctionY;
			playerController.sensitivityX = defaultSensitivityX;
			playerController.sensitivityY = defaultSensitivityY;
		}
	}
}