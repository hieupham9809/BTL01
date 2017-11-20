using UnityEngine;
using System.Collections;
 

public class PauseControler : MonoBehaviour {

	// Use this for initialization

	public Transform canvas;                        //the canvas

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();                               //pause the game if player press Escape
		}
	}
	public void Pause(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);     //set pause menu on
			Time.timeScale = 0;                     //stop the time
		} else {
			canvas.gameObject.SetActive (false);    //set pause menu off
			Time.timeScale = 1;	                    //turn on the time
		}
	}

	public void MainMenu(){
		Application.LoadLevel ("MainMenu");         //load main menu
	}

	public void Quit(){
		Application.Quit ();                        //quit the game
	}

	public void TurnOffSound(){
		if (AudioListener.volume == 0)
			AudioListener.volume = 1;               //turn on the sounds
		else
			AudioListener.volume = 0;               //turn off the sounds
	}
}
