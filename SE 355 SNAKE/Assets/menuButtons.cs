using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtons : MonoBehaviour {

	public void doQuit(){
		Debug.Log ("quit!");
		Application.Quit ();
	}

	public void startGame(){
		Debug.Log ("oyunu aç!");
		Application.LoadLevel ("GamePlay");
	}
}
