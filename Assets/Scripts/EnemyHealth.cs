using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	//Health Variables
	public float currentHealth = 100;
	public float PlayerBullet = 20.0f;
	public float PlayerGrenade = 50.0f;


	//AudioFiles
	//public AudioClip Explosion;
	public AudioClip Scream;

	//Rapto Death Particle effect
	public Transform bloodSpawner;
	public GameObject bloodSquirt;





	//Audio files
	//public AudioClip sound2;
	//public AudioClip Explosion;

	//Explosion Particle effect here
	//public GameObject Explode;

	//Josh's Script



	// Use this for initialization
	void Start () 
	{
		//bloodSquirt = GetComponent<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider raptor)
	{

		//Bullet damage code
		if (raptor.gameObject.CompareTag ("Bullet")) 
		{
			
			//Scream.PlayOneShot(sound, 0.8f);
			AudioSource.PlayClipAtPoint(Scream,transform.position);
			currentHealth -= PlayerBullet;


			Debug.Log("Hit by Bullet!");
			//AudioSource.PlayClipAtPoint(Scream, transform.position);


		}

		//Grenade damage code
		if (raptor.gameObject.CompareTag ("Grenade")) 
		{
			//Scream.PlayOneShot(sound, 0.8f);
			currentHealth -= PlayerGrenade;

			Debug.Log("Hit by Grenade!");
		}


		//Raptop Death
		if (currentHealth <= 0.0f) 
		{
			//AudioSource.PlayClipAtPoint(Explosion,transform.position);
			bloodSquirt = Instantiate(bloodSquirt, bloodSpawner.position, bloodSpawner.rotation);



			Destroy (this.gameObject);

			Debug.Log ("Raptor is DEAD!!!");
		}
	
	

		if(raptor.gameObject.CompareTag("Player"))
		{
			
			Destroy (this.gameObject);
			//Explosion.PlayOneShot(sound2, 0.8f);
			//StartCoroutine (Delayblast());
			//Destroy (this.gameObject);

		}


	}





}
