using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	//Health variables
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;

	public RectTransform healthbar;



	public void TakeDamage(int amount)
	{
		currentHealth -= maxHealth;

		if (currentHealth <= 0) {
			currentHealth = 0;
			Debug.Log ("hit!");

			healthbar.sizeDelta = new Vector2 (currentHealth, healthbar.sizeDelta.y);
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
