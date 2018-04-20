using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	
	public DestroyGameObject DestroyGameObject_script;

	public static bool GameIsPaused;
	public GameObject pauseMenuUI;
	public GameObject menuButton;
	public GameObject gameOverMenuUI;
	public Text scoreUI;
	public Text highScoreUI;

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
			DestroyGameObject_script.scoreUI.enabled = false;
			highScoreUI.text = "High Score: "+PlayerPrefs.GetInt ("HighScore");
			scoreUI.text = "Score: " + DestroyGameObject_script.score;
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
