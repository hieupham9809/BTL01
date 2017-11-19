using UnityEngine;
using System.Collections;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("level1");
	}

	public void BackToMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
