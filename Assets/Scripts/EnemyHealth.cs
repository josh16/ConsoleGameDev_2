using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	//Health Variables
	public float currentHealth = 100;
	public float PlayerBullet = 25.0f;
	public float PlayerGrenade = 50.0f;


	//AudioFiles
	//public AudioClip Explosion;
	public AudioClip Scream;



	//Audio files
	//public AudioClip sound2;
	//public AudioClip Explosion;

	//Explosion Particle effect here
	//public GameObject Explode;

	//Josh's Script


	void OnTriggerEnter(Collider zambie)
	{

		//Bullet damage code
		if (zambie.gameObject.CompareTag ("Bullet")) 
		{
			
			//Scream.PlayOneShot(sound, 0.8f);
			AudioSource.PlayClipAtPoint(Scream,transform.position);
			currentHealth -= PlayerBullet;

			Debug.Log("BULLET!!! hit!!");
			//AudioSource.PlayClipAtPoint(Scream, transform.position);


		}

		//Grenade damage code
		if (zambie.gameObject.CompareTag ("Grenade")) 
		{
			//Scream.PlayOneShot(sound, 0.8f);
			currentHealth -= PlayerGrenade;

			Debug.Log("GRENADE!! hit!!");
		}


		//Zambie Death
		if (currentHealth <= 0.0f) 
		{
			//AudioSource.PlayClipAtPoint(Explosion,transform.position);

			Destroy (this.gameObject);

			Debug.Log ("Zambie is DEAD!!!");
		}
	
	

		if(zambie.gameObject.CompareTag("Player"))
		{
			
			Destroy (this.gameObject);
			//Explosion.PlayOneShot(sound2, 0.8f);
			//StartCoroutine (Delayblast());
			//Destroy (this.gameObject);

		}


	}




	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
