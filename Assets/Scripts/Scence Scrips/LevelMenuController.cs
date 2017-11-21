using UnityEngine;
using System.Collections;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("level1");       //Loading level 1
	}

	public void BackToMenu(){
		Application.LoadLevel ("MainMenu");     //Loading main menu
	}

	public void BossLevel(){
		Application.LoadLevel ("Level_boss"); // Loading Level Boss
	}
}
