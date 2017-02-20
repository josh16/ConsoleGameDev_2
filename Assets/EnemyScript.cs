using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {



	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject; // Collides with gameobject
		var health = hit.GetComponent<PlayerHealth> ();// calling the PlayerHealth script

		//Taking Damage
		if (health != null) {

			health.TakeDamage (10);

		}
			
	}




}
