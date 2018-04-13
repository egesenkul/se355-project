using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused;
	public GameObject pauseMenuUI;
	public GameObject menuButton;

	void Start (){
		menuButton = GameObject.Find ("ButtonPause");
		GameIsPaused = false;
	}

	void Update () {
		if (GameIsPaused) {
			Pause ();
		} else {
			Resume ();
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1; //freeze time in game
		GameIsPaused = false;
		menuButton.SetActive (true);
	}

	void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f; //freeze time in game
	}

	public void OpenPauseMenu(){
		Debug.Log ("pause");
		GameIsPaused = true;
		menuButton.SetActive (false);
	}

	public void ExitGame(){
		Application.Quit();
	}

	public void OpenMainMenu(){
		Application.LoadLevel ("Menu");
	}
}
