using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplodes : MonoBehaviour 
{

	public Transform particleSpawner;
	public GameObject Explosion;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine(DestroyGrenade());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
			{
				Instantiate (Explosion, particleSpawner.position, particleSpawner.rotation);
				Destroy(this.gameObject);
				Debug.Log ("Destroyed!!");

			}
	
	

		if(other.gameObject.CompareTag("Boss"))
		{
			Instantiate (Explosion, particleSpawner.position, particleSpawner.rotation);
			Destroy(this.gameObject);
			Debug.Log ("Destroyed!!");

		}


			
	}


	IEnumerator DestroyGrenade()
	{
		yield  return new  WaitForSeconds (2.0f);
		Instantiate (Explosion, particleSpawner.position, particleSpawner.rotation);

		Destroy (this.gameObject);	
	}


}
