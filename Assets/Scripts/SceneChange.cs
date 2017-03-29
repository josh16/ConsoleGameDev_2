using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour 
{

	void Start()
	{
		//Time.timeScale = 1;

	}
	public void NextLevelButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	/*public void Exit ()
	{
		Application.Quit();
	}
	*/
}

