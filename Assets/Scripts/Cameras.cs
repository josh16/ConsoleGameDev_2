using UnityEngine;
using System.Collections;

public class Cameras : MonoBehaviour 
{
	//public bool activateself;

	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	public GameObject cam4;
	// Use this for initialization
	void Start () 
	{
		cam1.SetActive (true);
		cam2.SetActive (false);
		cam3.SetActive (false);
		cam4.SetActive (false);
		//StartCoroutine(Change());
	}

	void Awake()
	{
		StartCoroutine(Change());
	}
	// Update is called once per frame
	void Update () 
	{
		//StartCoroutine(Change());
	}
	IEnumerator Change() 
	{
		while (true) 
		{
			yield return new WaitForSeconds (2);
			cam1.SetActive (true);
			cam2.SetActive (false);
			yield return new WaitForSeconds (2);
			cam2.SetActive (true);
			cam3.SetActive (false);
			yield return new WaitForSeconds (2);
			cam3.SetActive (true);
			cam4.SetActive (false);
			yield return new WaitForSeconds (2);
			cam4.SetActive (true);
			cam1.SetActive (false);
		}
	}
}
