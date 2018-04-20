using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
	public SnakeScript snake_script;
	public int i = 0;

	public RandomCreateObject sn;
	// Use this for initialization
	void Start () {
		snake_script = GameObject.Find ("Snake").GetComponent<SnakeScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] Cubeler;
		Cubeler = GameObject.FindGameObjectsWithTag("Cube");
		foreach (GameObject item in Cubeler) {
			if ((item.transform.position - transform.position).magnitude < 1.5f) {
				Destroy (item);
				snake_script.speed += 0.25f;
				sn.GenerateRandomObjectCube(1);
				if (i < 2) {
					i++;
					snake_script.AddBodyPart ();
				}
			}
		}
	}

}
