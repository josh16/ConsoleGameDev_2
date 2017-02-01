using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	//Health variables
	public const int maxHealth = 100;

	public int currentHealth = maxHealth;



	public void TakeDamage(int amount)
	{
		currentHealth -= maxHealth;

		if (currentHealth <= 0) {
			currentHealth = 0;

			Debug.Log("Oh no! i'm Dead!!");
			//Code right here will destroy the player
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}







}
