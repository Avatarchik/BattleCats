using UnityEngine;
using System.Collections;

public class ConstructionScript : MonoBehaviour {


	public string SelectedRoom;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit) && hit.transform.gameObject.tag == "EmptyRoom") {
				if (SelectedRoom == "Gym") {
					// Build Gym
					Debug.Log ("You Built a gym");
				}

				if (SelectedRoom == "Arcade") {
					Debug.Log ("You built an Arcade");

				}

				if (SelectedRoom == "Kitchen") {
					Debug.Log ("You built a Kitchen");
				}
			}
		}
	}


	
	public 	void SelectedGym()
		{
			SelectedRoom =  ("Gym");
		}

	public void SelectedArcade()
	{
		SelectedRoom = ("Arcade");

	}

	public void SelectedKitchen ()
	{
		SelectedRoom = ("Kitchen");
	}
}

