using UnityEngine;
using System.Collections;

public class LoadingScreenDelayScript : MonoBehaviour {


	public int CurrentTime;
	public int TargetTime;


	// Use this for initialization
	void Start () {
		CurrentTime = (int)System.DateTime.Now.Second;
		TargetTime = CurrentTime + 8;
	}
	
	// Update is called once per frame
	void Update () {

		CurrentTime = (int)System.DateTime.Now.Second;
		if (CurrentTime == TargetTime) 
		{

			GameObject.Find("[Mgr]LoadingSceneManager").GetComponent<LoadingSceneManager>().LoadScene("Prototype2.0");

		}
	
	}
}
