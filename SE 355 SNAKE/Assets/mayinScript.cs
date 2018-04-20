using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayinScript : MonoBehaviour {

	public DestroyGameObject DestroyGameObject_script;
	public RandomCreateObject sn;
	// Use this for initialization
	void Start () {
		DestroyGameObject_script = GameObject.Find ("Bodypart").GetComponent<DestroyGameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] Mayinlar;
		Mayinlar = GameObject.FindGameObjectsWithTag("mayin");
		foreach (GameObject item in Mayinlar) {
			if ((item.transform.position - transform.position).magnitude < 1.5f) {
				Destroy (item);
				DestroyGameObject_script.score=DestroyGameObject_script.score-5;
				Handheld.Vibrate ();
				DestroyGameObject_script.scoreUI.text = "Score: "+DestroyGameObject_script.score.ToString ();
				sn.GenerateRandomObjectMayin(1);
			}
		}
	}
}
