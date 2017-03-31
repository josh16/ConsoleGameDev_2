using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RunePlayerScript : MonoBehaviour
{
	public AudioClip RunePickup;
	public AudioClip RuneDropOff;
    // ---------------  green rune --------------------------------//
    // text updating the green runes status
   // public Text m_greenRuneText;

    // bool for checking if green rune is picked up
    public bool m_greenPickedUp = false;

    //bool for checking if the rune is dropped off
    public bool m_greenDroppedOff = false;


    // -------------------------- yellow rune  -----------------------------//

    // text updating the yellow runes status
    //public Text m_yellowRuneText;


    // bool for checking if yellow rune is picked up
    public bool m_yellowPickedUp = false;

    //bool for checking if the rune is dropped off
    public bool m_yellowDroppedOff = false;

    // --------------------------------- blue rune ----------------------//

    // text updating the blue runes status
    // public Text m_blueRuneText;

    // bool for checking if blue rune is picked up
    public bool m_bluePickedUp = false;

    //bool for checking if the rune is dropped off
    public bool m_blueDroppedOff = false;



    // ----------------------- sounds -----------------------------//

    // sound for picking up rune
    //need clip and audio source




    // sound for dropping off rune
    // need clip and audio source



    private void Start()
    {
        // setting up all 3 texts to be implemented

    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GreenRune"))
        {
            // destroys rune and makes bool true
            Destroy(other.gameObject);
            m_greenPickedUp = true;
            // play pickup sound
            // when bool is true that when we switch the text
            // edit text saying rune is retrieved 
			AudioSource.PlayClipAtPoint(RunePickup, transform.position);
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
            Debug.Log("yellow rune picked up");
        }
        if(other.gameObject.CompareTag("GreenRuneDropOff") && m_greenPickedUp == true)
        {
            // play dropping off sound
            m_greenDroppedOff = true;
            m_greenPickedUp = false;
            // change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
            Debug.Log("green rune dropped off");

        }
        if (other.gameObject.CompareTag("BlueRuneDropOff") && m_bluePickedUp == true)
        {
            // play dropping off sound
            m_blueDroppedOff = true;
            m_bluePickedUp = false;
            // change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
            Debug.Log("blue rune dropped off");

        }
        if (other.gameObject.CompareTag("YellowRuneDropOff") && m_yellowPickedUp == true)
        {
            // play dropping off sound
            m_yellowDroppedOff = true;
            m_yellowPickedUp = false;
            // change text saying green rune activated
			AudioSource.PlayClipAtPoint(RuneDropOff, transform.position);
            Debug.Log("yellow rune dropped off");

        }
        if( (other.gameObject.CompareTag("NextLevel") ) && ( (m_greenDroppedOff == true) && (m_blueDroppedOff == true) && (m_yellowDroppedOff == true) ) )
        {
            SceneManager.LoadScene("Labratory");
        }

    }


}
