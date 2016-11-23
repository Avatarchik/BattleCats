using UnityEngine;
using System.Collections;

public class RoomViewerScript : MonoBehaviour {


	public GameObject RoomCamera;
	public GameObject MainCamera;
	public GameObject RoomStats;
	public GameObject RoomUI;
	public GameObject GameUI;

	public int TapCount;
	public float TapTime = 2;

	public bool RoomBeingWatched;


	// Use this for initialization
	void Start () {
		GameUI = GameObject.Find ("UI");
		MainCamera = GameObject.Find ("Main Camera");
	
	}


	public void CameraSelected()
	{
		RoomCamera.SetActive (true);
		MainCamera.SetActive (false);
		RoomUI.SetActive (true);
		GameUI.SetActive (false);
		RoomStats.SetActive (true);
			

	
		//CameraManager.DeactivateMainCamera ();
		Debug.Log ("Main Camera should be disabled");
	}

	public void CameraDeselected()
	{
		RoomCamera.SetActive (false);
		MainCamera.SetActive (true);
		RoomUI.SetActive (false);
		GameUI.SetActive (true);
		RoomStats.SetActive (false);
	}



	
	// Update is called once per frame
	void Update () {




		if (Input.touchCount == 2)
			{
			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
				CameraSelected ();
				Debug.Log ("Room has been touched");
			}
		}


	}


}

	

