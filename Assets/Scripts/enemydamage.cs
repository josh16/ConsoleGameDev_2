using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemydamage : MonoBehaviour
{

    //score when killing zombies
    public Text m_scoreText;
    //public int m_score = 0;
	//PlayerPrefs.SetInt("Score", 0);

	//Matt's Script
    void Start()
    {

        //grabbing the score text 
         m_scoreText = GameObject.Find("UI_Canvas").transform.FindChild("numbers").GetComponent<Text>();

        //m_score = 0;
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
			PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 50);
			m_scoreText.text = PlayerPrefs.GetInt("Score").ToString("f0");
            Destroy(other.gameObject);
            //Destroy(gameObject);
           

        }
    
	
	}





}
