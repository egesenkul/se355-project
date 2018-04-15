using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class menuButtons : MonoBehaviour {

	public Text hs;

	void Start(){
		hs.text = "High Score: "+PlayerPrefs.GetInt ("HighScore").ToString();
	}

	public void doQuit(){
		Debug.Log ("quit!");
		Application.Quit ();
	}

	public void startGame(){
		Application.LoadLevel ("GamePlay");
	}
}
