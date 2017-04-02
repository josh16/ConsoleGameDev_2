using UnityEngine;
using System.Collections;

public class levelload : MonoBehaviour {

	public void TransitionToScene(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}
}
