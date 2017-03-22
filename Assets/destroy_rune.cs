using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy_rune : MonoBehaviour
{
	public int m_runeCounter = 0;
	public GameObject m_deleteSpawner = null;


	public Text m_runeText;


	void Start()
	{
		m_runeText = GameObject.Find ("Canvas").transform.FindChild ("runetext").GetComponent<Text> ();


	}


	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Destroy (gameObject);
			m_runeCounter++;
			m_runeText.text = m_runeCounter.ToString ("f0");

			if(m_runeCounter == 3)
			{
				Destroy (m_deleteSpawner);
				Debug.Log ("Spawner is deleted.. no more runes coming in");
			}
		
		}

	}

}
