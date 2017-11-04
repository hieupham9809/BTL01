using UnityEngine;
using System.Collections;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("Huan_tempscence");
	}

	public void BackToMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
