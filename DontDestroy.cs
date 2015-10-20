using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// The gameObject with this component will not be destroyed when scenes change
	void Awake()
	{
		DontDestroyOnLoad (this);
	}
}
