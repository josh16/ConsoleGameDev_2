using UnityEngine;
using System.Collections;
// had to add in UI so it can actually take in ui stuff
using UnityEngine.UI;
// scene management is the new way for the changing of scenes. 
using UnityEngine.SceneManagement;
using UnityEngine.Networking;




public class UI :  NetworkBehaviour
{

    
	//Matt's Script

	// the visual of the health bar
	public AudioClip Damage;
	public AudioClip Heal;
    public Image m_healthBar;
    // the amount of health
    private float m_tempHealth = 1.0f;


    // not only will there be a health bar, but a number to show the player 

    // this is the health being shown to the player
    public Text m_healthText;
    
	[SyncVar]
	public float m_health = 100f;


    void Start()
    {
        // this finds the canvas, then looks for something called health bar
        m_healthBar = GameObject.Find("UI_Canvas").transform.FindChild("Health Bar").GetComponent<Image>();

        // samething again, this finds the health text
       m_healthText.GetComponent<Text>();
    }





    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Enemy")||(other.gameObject.CompareTag("Boss")))
        {
			if (!isServer)
			{
				return;
			}

			// if the health is greater than 0 , and not equal or less than zero....... take health from player
            if (m_tempHealth > 0 && (m_tempHealth != 0 || m_tempHealth < 0))
            {
                // updating the health bar number
                m_tempHealth -= 0.05f;
				AudioSource.PlayClipAtPoint(Damage,transform.position);
                //updating the health bar visually
                m_healthBar.fillAmount = m_tempHealth;


                // update visual number to how much health is remaining
                m_health -= 0.05f * 100f;
                // using a string, print it out to the screen
                m_healthText.text = m_health.ToString("f0");


                // sounds can go here if any
                


            }
            if(m_tempHealth <= 0)
            {
                // if the health is 0 or less, gameover

				//Preserve the main camera so it doesn't get destroyed.
				Camera.main.transform.parent=null;

				Destroy(this.gameObject);
				//camera.
				SceneManager.LoadScene("GameOver");
            }

        }


        if (other.gameObject.CompareTag("Pickup"))
        {
            // basically checking if the player is still alive he can pickup health
            // or if the player is at 100% the player wont be able to pickup any more health
            if ((m_tempHealth > 0 && m_tempHealth != 1f) && (m_tempHealth != 0 || m_tempHealth < 0))
            {
                m_tempHealth += 0.05f;
				AudioSource.PlayClipAtPoint(Heal,transform.position);
                m_healthBar.fillAmount = m_tempHealth;
                
                m_health += 0.05f * 100f;
                m_healthText.text = m_health.ToString("f0");


                Destroy(other.gameObject);


                // sounds can go here if any
                // from the example
                //soundHealthClip.PlayOneShot(healthClip, 1f);

            }
        }
    }



}
