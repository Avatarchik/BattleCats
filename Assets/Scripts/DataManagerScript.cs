using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class DataManagerScript : MonoBehaviour {



	public string CatName;
	public InputField CatNameInput;

	int m = (int)System.DateTime.Now.Minute;
	int CurrentTime = (int)System.DateTime.Now.Minute;
	int StartTime;
	int Difference;

	// Use this for initialization
	void Start () {

		// Gets the time the training started from the file and assigns it to a variable
		StartTime = PlayerPrefs.GetInt("StartTime");

		// Subtracts the Current time to the time the training started to find ouut the difference
		Difference = CurrentTime - StartTime;
		CatName = "DAS";
	
	}
	
	// Update is called once per frame
	void Update () {



		// Displays the current time
		if (Input.GetKeyDown (KeyCode.F2)) 
		{
			Debug.Log ("Current Time is" + CurrentTime);
		}



		// Saves the time the training started to a external file
		if (Input.GetKeyDown (KeyCode.F3)) 
		{
			CatNames();
			PlayerPrefs.SetInt (CatName, m);
			Debug.Log (CatName +" Has been saved");
		}



		// Print the time the training started
		if (Input.GetKeyDown (KeyCode.F4)) 
		{
			print( PlayerPrefs.GetInt ("StartTime"));
		}


		// When pressed it displays the amount of time that has passed
		if (Input.GetKeyDown (KeyCode.F5)) 
		{
			Debug.Log ("The difference is " +Difference);
		}

	
	}



	public void CatNames()
	{
		CatName = CatNameInput.text;

	}
}
