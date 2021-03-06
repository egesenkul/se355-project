﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
	// This script for giving a gravity for to world - EGE 
	float gravityForce = -150;

	public void ApplyGravity(Transform reciever){
		Rigidbody rb = reciever.GetComponent<Rigidbody> ();
		Vector3 forceUp = reciever.position - transform.position;
		Vector3 dir;
		dir = gravityForce * forceUp.normalized;

		rb.AddForce (dir);
		Vector3 recieverUp = reciever.up;

		Quaternion rot = Quaternion.FromToRotation (recieverUp, forceUp) * reciever.rotation;

		reciever.rotation = rot;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
