using UnityEngine;
using System.Collections;

public class MainCameraManager : MonoBehaviour {

	public GameObject MainCamera;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ActivateMainCamera()
	{
		MainCamera.SetActive (true);
	}

	public void DeactivateMainCamera()
	{
		MainCamera.SetActive (false);
		Debug.Log ("But it fecking aint");
	}
}
