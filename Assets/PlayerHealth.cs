using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

	//Health variables
	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]

	public int currentHealth = maxHealth;

	public RectTransform healthbar;


	//Take Damage Function
	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;

		currentHealth -= maxHealth;

		if (currentHealth <= 0) {
			currentHealth = 0;

			currentHealth = maxHealth;

			// called on the Server, but invoked on the Clients
			RpcRespawn();

		}

	}


	//HealthBar Function	
	void OnChangeHealth(int currentHealth )
	{
		healthbar.sizeDelta = new Vector2 (currentHealth, healthbar.sizeDelta.y);

	}




	//RESPAWN FUNCTION

	//This functin will now be run on clients when it's called on the server.
	[ClientRpc] // makes a function into a ClientRpc Call
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// move back to zero location
			transform.position = Vector3.zero;
		}

	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}







}
