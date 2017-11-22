using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("LevelMenu");    //loading level menu
	}

	public void ExitGame(){
		Application.Quit ();                    //quit the game
	}
}
