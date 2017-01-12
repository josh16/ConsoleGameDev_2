using UnityEngine;
using System.Collections;

public static class InputManager //Static class
{


	//Horizontal axis
	public static float MainHorizontal()
	{
		float r = 0.0f;
		r += Input.GetAxis ("J_MainHorizontal");

		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	//Vertical Axis
	public static float MainVertical()
	{
		float r = 0.0f;
		r += Input.GetAxis ("J_MainVertical");

		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	//
	public static  Vector3 MainJoystick()
	{
		return new Vector3(MainHorizontal(),0, MainVertical()); 
	}


	//Button functions
	public static bool squareButton()
	{
		return Input.GetButtonDown ("square_Button");

	}

	public static bool xButton()
	{
		return Input.GetButtonDown ("x_Button");

	}


	public static bool circleButton()
	{
		return Input.GetButtonDown ("circle_Button");

	}

	public static bool triangleButton()
	{
		return Input.GetButtonDown ("triangle_Button");

	}



}
