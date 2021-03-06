﻿using UnityEngine;
using System.Collections;

public class WidgetMenuControlScript : MonoBehaviour {

	public GameObject OpenButton;
	public GameObject CloseButton;
	public GameObject CatStatsOpen;
	public GameObject CatStatsClose;
	public GameObject ConstructionButton;

	public GameObject ConstructionIcons;
	public GameObject WidgetIcons;

	public Animator WidgetMenuButton;
	public Animator StrayStats;
	public Animator HouseStats;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}



	public void ShowHouseCatStats()
	{
		HouseStats.SetBool ("HouseCatsStatsShown", true);
		CatStatsOpen.SetActive (false);
		CatStatsClose.SetActive (true);
	}

	public void HideHouseCatStats()
	{
		HouseStats.SetBool ("HouseCatsStatsShown", false);
		CatStatsOpen.SetActive (true);
		CatStatsClose.SetActive (false);

	}





	public void ShowConstructionMenu()
	{
		WidgetIcons.SetActive  (false);
		ConstructionIcons.SetActive  (true);
	}

	public void HideConstructionMenu()
	{
		WidgetIcons.SetActive  (true);
		ConstructionIcons.SetActive (false);
	}

	public void ShowStrayCatStats()
	{
		StrayStats.SetBool ("StrayCatsStatsShown", true);
	}

	public void HideStrayCatStats()
	{
		StrayStats.SetBool ("StrayCatsStatsShown", false);

	}


	public void OpenMenu()
	{
		WidgetMenuButton.SetBool ("MenuShown", true);
		OpenButton.SetActive (false);
		CloseButton.SetActive (true);
	}

	public void CloseMenu()
	{
		WidgetMenuButton.SetBool ("MenuShown", false);
		OpenButton.SetActive (true);
		CloseButton.SetActive (false);
	}








}
