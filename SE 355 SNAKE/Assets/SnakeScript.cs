﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour {
	public float minSwipeDist=50;

	public List<Transform> BodyParts = new List<Transform> ();
	public float mindistance = 0.25f;
	public int beginsize=1;

	public bool ters=false;
	public bool swipeRight=false;
	public bool swipeLeft=false;

	private float maxSpeed =10;

	float swipeDistance;

	Vector3 startPos;
	Vector3 endPos;

	public float speed = 1;
	public float rotationSpeed= 90;

	public GameObject bodyprefab;

	private float dis;
	private Transform curBodyPart;
	private Transform PrevBodyPart;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < beginsize - 1; i++) {
			AddBodyPart ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if(Input.GetKeyDown(KeyCode.Q)){
			AddBodyPart();
		}
	}

	public void Move(){
		float curspeed = speed;
		if (speed > maxSpeed) {
			curspeed = maxSpeed;
		}
		BodyParts[0].Translate(BodyParts[0].forward*curspeed*Time.smoothDeltaTime,Space.World);
		if (swipeRight) {
			if (!ters) {
				BodyParts [0].Rotate (Vector3.up * rotationSpeed * Time.deltaTime * 10);
			} else {
				BodyParts [0].Rotate (Vector3.up * rotationSpeed * Time.deltaTime * -10);
			}
		} else if (swipeLeft) {
			if (!ters) {
				BodyParts [0].Rotate (Vector3.up * rotationSpeed * Time.deltaTime * -10);
			} else {
				BodyParts [0].Rotate (Vector3.up * rotationSpeed * Time.deltaTime * 10);
			}
		}
		swipeLeft = swipeRight = false;
		for(int i =1;i<BodyParts.Count;i++){
			curBodyPart = BodyParts[i];
			PrevBodyPart = BodyParts[i-1];

			dis = Vector3.Distance(PrevBodyPart.position,curBodyPart.position);

			Vector3 newpos = PrevBodyPart.position;

			newpos.y = BodyParts[0].position.y;

			float T = Time.deltaTime*dis/mindistance*curspeed;

			if(T> 0.5f)
				T=0.5f;

			curBodyPart.position = Vector3.Slerp(curBodyPart.position,newpos,T);
			//curBodyPart.position = newpos;
			curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation,PrevBodyPart.rotation,T);
		}

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startPos = touch.position;

			}  else if (touch.phase == TouchPhase.Ended) {
				endPos = touch.position;

				swipeDistance = (endPos - startPos).magnitude;

				if (swipeDistance > minSwipeDist) {
					Vector2 distance = endPos - startPos;

					if (distance.y > 0) {
					//	AddBodyPart ();
					} else if (distance.y < 0) {
						if (beginsize != 3) {
							beginsize++;
						}
						if (Input.GetKeyDown (KeyCode.A) || distance.x > 0) {
							swipeRight = true;
							swipeLeft = false;
						} else if (Input.GetKeyDown (KeyCode.Z) || distance.x < 0) {
							swipeRight = false;
							swipeLeft = true;
						}
					}
				}
			}
		}
			
	}

	public void AddBodyPart(){
			//position,BodyParts[BodyParts.Count-1].rotation
		Transform newpart = (Instantiate(bodyprefab,BodyParts[BodyParts.Count-1]. position,BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;
		newpart.SetParent (transform);
		BodyParts.Add (newpart);
	}
}
