using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFromPC : MonoBehaviour {
	// This script for control player with computer inputs - EGE 
	private PlayerController ps;

	// Use this for initialization
	void Start () {
		ps = GameObject.Find ("Sphere").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			ps.swipeLeft = true;
			ps.swipeDown = false;
			ps.swipeRight = false;
			ps.swipeUp = false;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			ps.swipeLeft = false;
			ps.swipeDown = false;
			ps.swipeRight = false;
			ps.swipeUp = true;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			ps.swipeLeft = false;
			ps.swipeDown = false;
			ps.swipeRight = true;
			ps.swipeUp = false;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			ps.swipeLeft = false;
			ps.swipeDown = true;
			ps.swipeRight = false;
			ps.swipeUp = false;
		}
	}
}
