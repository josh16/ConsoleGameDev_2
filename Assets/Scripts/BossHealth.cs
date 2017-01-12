using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour 
{

	// matts script again

	public Image m_healthBar;
	// the amount of health
	private float m_tempHealth = 1.0f;

	//Audio references
	public AudioClip Scream;


	void Start()
	{

		m_healthBar = GameObject.Find("Canvas").transform.FindChild("bosshealth").GetComponent<Image>();   
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{

			if (m_tempHealth > 0 && (m_tempHealth != 0 || m_tempHealth < 0))
			{
				AudioSource.PlayClipAtPoint(Scream,transform.position);
				m_tempHealth -= 0.05f;
				m_healthBar.fillAmount = m_tempHealth;

			}

			if (m_tempHealth <= 0)
			{
				Destroy(this.gameObject);
				SceneManager.LoadScene ("Win");
			}

		}

		if (other.gameObject.CompareTag("Grenade"))
		{

			if (m_tempHealth > 0 && (m_tempHealth != 0 || m_tempHealth < 0))
			{
				AudioSource.PlayClipAtPoint(Scream,transform.position);
				m_tempHealth -= 0.05f;
				m_healthBar.fillAmount = m_tempHealth;

			}



			if (m_tempHealth <= 0)
			{
				Destroy(this.gameObject);
				SceneManager.LoadScene ("Win");
			}

		}
	
	
	
	
	
	}



	/*

    void OnTriggerEnter(Collider Bosszambie)
	{
		if (Bosszambie.gameObject.CompareTag ("Bullet")) 
		{
			//Scream.PlayOneShot(sound, 0.8f);
			currentHealth -= PlayerBullet;


            m_healthBar.fillAmount = currentHealth;

            Debug.Log("BossZambie hit!!");
		}


		//Zambie Death
		if (currentHealth <= 0.0f) 
		{
			//AudioSource.PlayClipAtPoint(Explosion,transform.position);

			Destroy (this.gameObject);

			Debug.Log ("BossZambie is DEAD!!!");
		}

	}




    */

}
