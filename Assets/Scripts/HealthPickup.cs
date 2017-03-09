using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {



	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Destroy (this.gameObject);

		}
	}


}
