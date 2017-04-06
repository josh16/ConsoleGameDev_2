using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RunePlayerScript : MonoBehaviour
{
	public AudioClip RunePickup;
	public AudioClip RuneDropOff;



	//Light Reference
	public GameObject greenLight;

	// ---------------  green rune --------------------------------//
	// text updating the green runes status
	public Text m_greenRuneText;


	// bool for checking if green rune is picked up

	private bool m_greenPickedUp = false;

	//bool for checking if the rune is dropped off

	private bool m_greenDroppedOff = false;


	// -------------------------- yellow rune  -----------------------------//

	// text updating the yellow runes status

	public Text m_yellowRuneText;

	// bool for checking if yellow rune is picked up

	private bool m_yellowPickedUp = false;

	//bool for checking if the rune is dropped off

	private bool m_yellowDroppedOff = false;

	// --------------------------------- blue rune ----------------------//

	// text updating the blue runes status
	public Text m_blueRuneText;

	// bool for checking if blue rune is picked up

	private bool m_bluePickedUp = false;

	//bool for checking if the rune is dropped off

	private bool m_blueDroppedOff = false;



	// ----------------------- sounds -----------------------------//

	// sound for picking up rune
	//need clip and audio source




	// sound for dropping off rune
	// need clip and audio source



	private void Start()
	{
		// example of how it should be laid out

		// Rune status: (where the text goes)

		// setting up all 3 texts to be implemented
		m_greenRuneText = GameObject.Find("Canvas").transform.FindChild("greentext").GetComponent<Text>();
		m_yellowRuneText = GameObject.Find("Canvas").transform.FindChild("yellowtext").GetComponent<Text>();
		m_blueRuneText = GameObject.Find("Canvas").transform.FindChild("bluetext").GetComponent<Text>();


	
	}




	private void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.name);
		if(other.gameObject.CompareTag("GreenRune"))
		{
			// destroys rune and makes bool true
			Destroy(other.gameObject);
			m_greenPickedUp = true;
			// play pickup sound
			// when bool is true that when we switch the text
			// edit text saying rune is retrieved 
			AudioSource.PlayClipAtPoint(RunePickup, transform.position);
			m_greenRuneText.color = Color.yellow;
			m_greenRuneText.text = "Green Rune Picked Up!";


			Debug.Log("green rune picked up");
		}
		if (other.gameObject.CompareTag("BlueRune"))
		{
			// destroys rune and makes bool true
			Destroy(other.gameObject);
			m_bluePickedUp = true;
			// play pickup sound
			// when bool is true that when we switch the text
			// edit text saying rune is retrieved 
			AudioSource.PlayClipAtPoint(RunePickup, transform.position);
			m_blueRuneText.color = Color.yellow;
			m_blueRuneText.text = "Blue Rune Picked Up!";

			Debug.Log("blue rune picked up");
		}
		if (other.gameObject.CompareTag("YellowRune"))
		{
			// destroys rune and makes bool true
			Destroy(other.gameObject);
			m_yellowPickedUp = true;
			// play pickup sound
			// when bool is true that when we switch the text
			// edit text saying rune is retrieved 
			AudioSource.PlayClipAtPoint(RunePickup, transform.position);
			m_yellowRuneText.color = Color.yellow;
			m_yellowRuneText.text = "Yellow Rune Picked Up!";
			Debug.Log("yellow rune picked up");
		}
		if(other.gameObject.CompareTag("GreenRuneDropOff") && m_greenPickedUp == true)
		{
			// play dropping off sound
			greenLight.SetActive (true);
			m_greenDroppedOff = true;
			m_greenPickedUp = false;
			// change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
			m_greenRuneText.color = Color.green;

			m_greenRuneText.text = "Green Rune Activated!";

			Debug.Log("green rune dropped off");

		}
		if (other.gameObject.CompareTag("BlueRuneDropOff") && m_bluePickedUp == true)
		{
			// play dropping off sound
			m_blueDroppedOff = true;
			m_bluePickedUp = false;
			// change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
			m_blueRuneText.color = Color.green;
			m_blueRuneText.text = "Blue Rune Activated!";
			Debug.Log("blue rune dropped off");

		}
		if (other.gameObject.CompareTag("YellowRuneDropOff") && m_yellowPickedUp == true)
		{
			// play dropping off sound
			m_yellowDroppedOff = true;
			m_yellowPickedUp = false;
			// change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
			m_yellowRuneText.color = Color.green;
			m_yellowRuneText.text = "Yellow Rune Activated!";
			Debug.Log("yellow rune dropped off");

		}

		//Destroy Text
		if(((m_greenDroppedOff == true) && (m_blueDroppedOff == true) && (m_yellowDroppedOff == true)))
		{

			m_greenRuneText.color = Color.white;
			m_greenRuneText.text = "DOOR IS UNLOCKED! \nPROCEED TO THE \nCENTER OF THE MAP!";
			Destroy (m_blueRuneText);
			Destroy (m_yellowRuneText);

		}

		if( (other.gameObject.CompareTag("NextLevel") ) && ( (m_greenDroppedOff == true) && (m_blueDroppedOff == true) && (m_yellowDroppedOff == true) ) )
		{
			SceneManager.LoadScene("Labratory");
		}

	}


}
