using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	private Transform parent;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
		// the "other" gameObject is just an enemy part (like head, body, ...). "Parent" is the real enemy, with all the logic.
			parent = other.transform.parent; 
			parent.SendMessage("bulletHitEnemy", SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		// If bullets go out of the level, destroy them.
		if (other.tag == "BulletsCollider") 
		{
			Destroy (gameObject);
		}
	}
}

