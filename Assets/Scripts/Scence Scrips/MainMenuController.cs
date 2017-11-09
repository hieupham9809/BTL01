using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("LevelMenu");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
