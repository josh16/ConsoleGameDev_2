using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public int m_Timer = 120;
    //public Text m_timerText;



	// Use this for initialization
	void Start ()
    {
        m_timerText = GameObject.Find("Canvas").transform.FindChild("timertext").GetComponent<Text>();

    }
	


	// Update is called once per frame
	void Update ()
    {
        m_Timer--;

        m_timerText.text = m_Timer.ToString("f0");

        if(m_Timer == 0)
        {
            SceneManager.LoadScene("Win");
        }



	}
}
