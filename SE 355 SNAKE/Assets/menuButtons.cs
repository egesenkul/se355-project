using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtons : MonoBehaviour {

	public void doQuit(){
		Debug.Log ("quit!");
		Application.Quit ();
	}

	public void startGame(){
		Application.LoadLevel ("GamePlay");
	}
}
