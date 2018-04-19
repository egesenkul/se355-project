using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	
	public DestroyGameObject DestroyGameObject_script;

	public static bool GameIsPaused;
	public GameObject pauseMenuUI;
	public GameObject menuButton;
	public GameObject gameOverMenuUI;

	void Start (){
		menuButton = GameObject.Find ("ButtonPause");
		DestroyGameObject_script = GameObject.Find ("Bodypart").GetComponent<DestroyGameObject> ();
		GameIsPaused = false;
	}

	void Update () {
		if (GameIsPaused) {
			Pause ();
		} else {
			Resume ();
		}
		if (DestroyGameObject_script.score < 0) {
			gameOverMenuUI.SetActive (true);
			Time.timeScale = 0f;
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

	public void TryAgain(){
		Application.LoadLevel ("GamePlay");
	}
}
