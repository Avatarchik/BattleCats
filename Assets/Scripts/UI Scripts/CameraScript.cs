﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public MobileInputScript MobileInput;
	public MobileInputScript MobileInputs;

	public float FOVZoomOut = 60;
	public float FOVZoomIn = 12;
	public float multiplier;

	private float lastPinchDistance = -1;

	void Log(string text)
	{
		GameObject.Find("Logger").GetComponent<UnityEngine.UI.Text>().text += "\n" + text;
	}
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		float multiplier = 0.01f;
	
			//PC
		if (!Input.touchSupported)
		{


			Vector2 offset = new Vector2(0, 0);

			if (Input.GetKey(KeyCode.W)) offset.y += multiplier; //UP
			if (Input.GetKey(KeyCode.S)) offset.y -= multiplier; //DN
			if (Input.GetKey(KeyCode.A)) offset.x -= multiplier; //LT
			if (Input.GetKey(KeyCode.D)) offset.x += multiplier; //RT

			Vector3 pos = transform.position;
			pos.x += offset.x;
			pos.y += offset.y;

			transform.position = pos;
		}
		//Mobile
		else
		{
			//PINCH-ZOOMING


			// -1, if the user is not actually pinching
			float currentPinchDistance = getPinchDistance();

			// When the user starts pinching, the lastPinchDistance
			// is updated from -1 to the current distance

			// Hence if the value is bigger than -1
			// we can get an accurate delta of the distances
			if (Input.touchCount > 1 && lastPinchDistance > -1)
			{
				Camera camera = GetComponent<Camera>();
				float delta = lastPinchDistance - currentPinchDistance;
				camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + delta * multiplier, FOVZoomIn, FOVZoomOut);


				//Clamp, so it doesn't exceed the limits of the zoom
				//pos.z = Mathf.Clamp(pos.z, -MinZoom, MaxZoom);
				//Update the transform of the camera
			}
			else if(Input.touchCount == 1)
			{
				if (MobileInput.CatPickedUp == true) 
				{
					multiplier = 0f;
					Debug.Log ("Cat Picked up ");
				}
				if (MobileInputs.CatPickedUp == true)
				{
					multiplier = 0f;
					Debug.Log ("Cat Picked Up");

				}
				//Moving
				Vector2 dPos = Input.GetTouch(0).deltaPosition;
				//slow the movement
				dPos *= multiplier;

				transform.position += new Vector3(dPos.x, -dPos.y, 0);

			}
			// Always update the last pinch distance (even when -1)
			lastPinchDistance = currentPinchDistance;

		}
	}

	float getPinchDistance()
	{
		if (Input.touchCount < 2) return -1;
		Touch touch0 = Input.GetTouch(0);
		Touch touch1 = Input.GetTouch(1);

		return Vector2.Distance(touch0.position, touch1.position);
	}
}


