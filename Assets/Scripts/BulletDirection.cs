using UnityEngine;
using System.Collections;

public class BulletDirection : MonoBehaviour 
{
	public float speed = 1;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DestroyBullets ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, 0, speed);
	}


	void OnTrigger(Collider other)
	{
		if(other.gameObject.CompareTag("Wall"))

		{
			Destroy (this.gameObject);
			Debug.Log("Bullet Destroyed!");
		}
	
	
		if(other.gameObject.CompareTag("Enemy"))
			{
				Destroy(this.gameObject);
			}
	
	
		if(other.gameObject.CompareTag("Pillar"))
		{
			Destroy(this.gameObject);
		}
	
	}

	void OnCollisionEnter()
	{
		Destroy(gameObject);
	}



	IEnumerator DestroyBullets()
	{
		yield return new WaitForSeconds (1.8f);
			Destroy(this.gameObject);
	}



}
