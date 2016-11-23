using UnityEngine;
using System.Collections;

public class RoomUpgradeScript : MonoBehaviour {

	public int BattleCoins;
	public string CurrentRoom;
	public GameObject ParentRoom;


	PlayerStatsScript playerStuff;


	// Use this for initialization
	void Start () {
		BattleCoins = playerStuff.BattleCatCoins;
	}


	public void UpgradeRoom()
	{
		CurrentRoom = ParentRoom.tag;



		if (CurrentRoom == "GymLevel1") 
		{
			BattleCoins = BattleCoins - 200;
			CurrentRoom = "GymLevel2";


		}

		if (CurrentRoom == "GymLevel2") 
		{
			BattleCoins = BattleCoins - 400;
			CurrentRoom = "GymLevel3";
			ParentRoom.tag = "GymLevel3";
		}


		if (CurrentRoom == "ArcadeLevel1") 
		{
			BattleCoins = BattleCoins - 200;
			CurrentRoom = "ArcadeLevel2";
		}

		if (CurrentRoom == "ArcadeLevel2") 
		{
			BattleCoins = BattleCoins - 400;
			CurrentRoom = "ArcadeLevel3";
		}

		if (CurrentRoom == "TreadMillLevel1") 
		{
			BattleCoins = BattleCoins - 200;
			CurrentRoom = "ArcadeLevel2";
		}

		if (CurrentRoom == "TreadMillLevel2") 
		{
			BattleCoins = BattleCoins - 400;
			CurrentRoom = "ArcadeLevel3";
		}


		if (CurrentRoom == "KitchenLevel1") 
		{
			BattleCoins = BattleCoins - 200;
			CurrentRoom = "KitchenLevel2";
		}


		if (CurrentRoom == "KitchenLevel2") 
		{
			BattleCoins = BattleCoins - 200;
			CurrentRoom = "KitchenLevel3";
		}
	
	}



	// Update is called once per frame
	void Update () {
	
	}
}
