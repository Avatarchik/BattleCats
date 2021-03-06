using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CattributesScript : MonoBehaviour {

	public GameObject Cat; 
	public string CatName;
	public static GameObject GymPosition;
	public int Strength;
	public int Agility;
	public int Perception;
	public int Energy =100;
	public int Hunger =100;

	public float PositionX;
	public float PositionY;


	public int CatMaxStats;


	public int Loops;

	public int TrainingStartTime;   // The time the cats training started
	public int TimePlayerQuit;
	public int TimeDifference;

	public int CurrentTime;     // Finds the systems time
	public int TrainingTime = 0;
	public string training;// Holds the type of training the cat is doing
	public string trainingType;
	public string HungerLevel;

	public Text CatNameText;
	public Text CatStrength;
	public Text CatAgility;
	public Text CatPerception;
	public Text CatEnergy;
	public Text CatHunger;
	public Text CatHungerLevel;
	public Text CatTraining;

	public string CatNameSaveFile;
	public string CatStrengthSaveFile;
	public string CatAgilitySaveFile;
	public string CatPerceptionSaveFile;
	public string CatEnergySaveFile;
	public string CatHungerSaveFile;
	public string CatHungerLevelSaveFile;
	public string CatTrainingSaveFile;
	public string CatXPositionSave;
	public string CatyPositionSave;

	void awake()
	{
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {

		CurrentTime = (int)System.DateTime.Now.Minute;
		CatName = Cat.name;
		CatNameSaveFile = "Name :"+CatName;
		CatStrengthSaveFile = CatName+"Strength";
		CatAgilitySaveFile = CatName+"Agility";
		CatPerceptionSaveFile = CatName+"Perception";
		CatEnergySaveFile = CatName+"Energy";
		CatHungerSaveFile = CatName+"Hunger";
		CatHungerLevelSaveFile = CatName + "HungerLevel";
		CatTrainingSaveFile = CatName+"Training";  
		CatXPositionSave = CatName + "XPosition";
		CatyPositionSave = CatName + "YPosition";

		if (gameObject.tag == "StrayCat") 
		{
			CatMaxStats = 20;

		}

		if (gameObject.tag == "HouseCat") 
		{
			CatMaxStats = 40;
		}

		if (gameObject.tag == "NinjaCat") 
		{
			CatMaxStats = 60;
		}

		// This sections loads in all the cattributes and training info
	
		TrainingStartTime= PlayerPrefs.GetInt("TrainingStartTime");	  // Loads in when the cat srtarted its training
		TimePlayerQuit  =PlayerPrefs.GetInt("TimePlayerQuit");	  // Loads in the Cats strength Level
		Strength  =PlayerPrefs.GetInt(CatStrengthSaveFile);	  // Loads in the Cats strength Level
		Agility  =PlayerPrefs.GetInt(CatAgilitySaveFile);	  // Loads in the Cats strength Level
		Perception  =PlayerPrefs.GetInt(CatPerceptionSaveFile);	  // Loads in the Cats strength Level
		Energy  =PlayerPrefs.GetInt(CatEnergySaveFile);	  // Loads in the Cats strength Level
		Hunger  =PlayerPrefs.GetInt(CatHungerSaveFile);	  // Loads in the Cats strength Level
		HungerLevel = PlayerPrefs.GetString(CatHungerLevelSaveFile);
		trainingType =PlayerPrefs.GetString(CatTrainingSaveFile);	  // Loads the current training
		PositionX = PlayerPrefs.GetFloat(CatXPositionSave);
		PositionY = PlayerPrefs.GetFloat (CatyPositionSave);
	
		TimeDifference = CurrentTime - TimePlayerQuit;    // When the game is started this calculates the time difference between when the game quit and the current time
		SetText();

		for (Loops = 0; TimeDifference > Loops; Loops++)   // For each minute that has passed the game loops
		{
			TrainingUpdate ();
			Debug.Log ("You trained for " + TimeDifference + trainingType + "Points");
		}

		TrainingTime = CurrentTime + 1;



		Cat.transform.position = new Vector3 (PositionX, PositionY,-0.5f);	
	


	}


	void TrainingUpdate()      // This method updates the cattributes over time
	{
		switch (trainingType) {

		case "Strength":

			Debug.Log ("Cat is training is Strength");


			if (Strength < CatMaxStats) 
			{
				if (training == "GymLevel1")
				{
					Strength++;
				} else 
				{
					if (training == "GymLevel2") 
					{
						Strength = Strength + 3;
					} 
					else if (training == "GymLevel3") 
					{
						Strength = Strength + 5;
					}
						
				}
			}
			Hunger--;
			Energy--;

			break;

		case "Agility":
			Debug.Log ("You are training Agility");


			if (Agility < CatMaxStats) {

				if (training == "TreadMillLevel1") 
				{
					Strength++;
				} 
				else if (training == "TreadMillLevel2")
				{
					Strength = Strength + 3;
				} 
				else if (training == "TreadMillLevel3") 
				{
					Strength = Strength + 5;
				}
			}
			Hunger--;
			Energy--;
			break;

		case "Perception":
			Debug.Log ("You are training Perception");
			if (Perception < CatMaxStats) 
			{
				if (training == "ArcadeRoomLevel1") 
				{
					Perception = Perception++;
				} 
				else if (training == "ArcadeRoomLevel2")
				{
					Perception = Perception + 3;
				} 
				else if (training == "ArcadeRoomLevel3") 
				{
					Perception = Perception + 5;
				}

			} 
			else 
			{
				Debug.Log ("This Cat has trained as far as it can in Perception");
			}
			Hunger--;
			Energy--;
			break;

		case "Kitchen":
			Debug.Log ("You are Eating at the kitchen");
			if (Hunger < 100 && Energy <100) {

				if (training == "KitchenLevel1") 
				{
					Hunger = Hunger + 10;
					Energy = Energy + 8;
				}
				else if (training == "KitchenLevel2") 
				{
					Hunger = Hunger + 15;
					Energy = Energy + 9;
				}
				else if (training == "KitchenLevel3") 
				{
					Hunger = Hunger + 20;
					Energy = Energy + 10;
				}
			} else
			{
				Debug.Log ("The cat is full");
			}

			break;
		case "InActive":
			Debug.Log ("Inactive");
			Hunger--;
			break;

		}
	}












	// Update is called once per frame
	void Update () {
		CatTraining.text = "Training : " + trainingType;
		CurrentTime = (int)System.DateTime.Now.Minute;
		if (CurrentTime == 0 && TrainingTime == 60)
		{
			TrainingTime = 1;
		}
		if (CurrentTime == TrainingTime)     // If the cat has been training for a certain amount of time then call the training method
		{
			TrainingUpdate ();
			TrainingTime = CurrentTime + 1;
			SetText ();

		}



		if (Hunger > 80) {
			Debug.Log ("The cat is well fed");
			HungerLevel = "HungerLevel :Well Fed";
		} 
		else if (Hunger > 50 && Hunger < 79)
		{
			Debug.Log (" The Cat is fed");
			HungerLevel = "Hunger Level : Fed";

		}
		else if (Hunger > 35 && Hunger < 49)
		{
			Debug.Log ("The cat is hungry");
			HungerLevel = "Hunger Level : Hungry";
		}
		else if (Hunger < 34 && Hunger > 1) 
		{
			Debug.Log ("Starving");
			HungerLevel = "Hunger Level : Starving";
		}






	}
		
	void SetText()
	{
		CatNameText.text = "Name : " + CatName ;
		CatStrength.text = "Strength :" + Strength +" / "+CatMaxStats ;
		CatAgility.text = "Agility :" + Agility + " / " + CatMaxStats;
		CatPerception.text = "Perception :" + Perception+" / "+ CatMaxStats;
		CatEnergy.text = "Energy :" + Energy +" / 100" ;
		CatHungerLevel.text = HungerLevel;
		CatHunger.text = "Hunger :" + Hunger+" / 100" ;
	}

	public void OnApplicationQuit()    // When the game is quit, its saves the Cats attributes to file 
	{
		PositionX = transform.position.x;
		PositionY = transform.position.y;



		TimePlayerQuit = CurrentTime;
		PlayerPrefs.SetString (CatNameSaveFile,CatName );
		PlayerPrefs.SetInt (CatStrengthSaveFile, Strength);
		PlayerPrefs.SetInt (CatAgilitySaveFile, Agility);
		PlayerPrefs.SetInt (CatPerceptionSaveFile, Perception);
		PlayerPrefs.SetInt (CatEnergySaveFile, Energy);
		PlayerPrefs.SetInt (CatHungerSaveFile, Hunger);
		PlayerPrefs.SetString (CatHungerLevelSaveFile, HungerLevel);
		PlayerPrefs.SetInt ("TimePlayerQuit", TimePlayerQuit);
		PlayerPrefs.SetString (CatTrainingSaveFile, trainingType);
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);
		TimeDifference = 0;
		Loops = 0;
	}

	void OnApplicationPause()
	{
		PositionX = transform.position.x;
		PositionY = transform.position.y;



		TimePlayerQuit = CurrentTime;
		PlayerPrefs.SetString (CatNameSaveFile,CatName );
		PlayerPrefs.SetInt (CatStrengthSaveFile, Strength);
		PlayerPrefs.SetInt (CatAgilitySaveFile, Agility);
		PlayerPrefs.SetInt (CatPerceptionSaveFile, Perception);
		PlayerPrefs.SetInt (CatEnergySaveFile, Energy);
		PlayerPrefs.SetInt (CatHungerSaveFile, Hunger);
		PlayerPrefs.SetInt ("TimePlayerQuit", TimePlayerQuit);
		PlayerPrefs.SetString (CatTrainingSaveFile, trainingType);
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);
		TimeDifference = 0;
		Loops = 0;

	}


	public void SaveGame()
	{
	

	}




	public void GymLevel1()     // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Strength";
		training = "GymLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
	}

	public void GymLevel2()     // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Strength";
		training = "GymLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
	}

	public void GymLevel3()     // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Strength";
		training = "GymLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
	}

	public void TreadMillLevel1()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}

	public void TreadMillLevel2()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}

	public void TreadMillLevel3()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}





	public void ArcadeLevel1()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}

	public void ArcadeLevel2()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}

	public void ArcadeLevel3()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}



		
	public void KitchenLevel1 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel1";
	}

	public void KitchenLevel2 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel2";
	}

	public void KitchenLevel3 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel3";
	}



	public void InActive()
	{
		trainingType = "InActive";
	}


	public void ResetStats ()    // Resets the Cattributes
	{
		Strength = 0;
		Agility = 0;
		Perception = 0;
		Energy = 100;
		Hunger = 100;
		trainingType = "InActive";
		SetText ();
	}
		


}


