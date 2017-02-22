using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour 
{

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// We have collided with a wall. 
			// Destroy player.
			Destroy(this.gameObject);
		}
		//Application.LoadLevel ("MainMenu");
	}
}
