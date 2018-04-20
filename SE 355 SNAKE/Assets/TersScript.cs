using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TersScript : MonoBehaviour {

	public DestroyGameObject DestroyGameObject_script;
	public RandomCreateObject sn;
	public SnakeScript ss;

	public float tenSec = 0;
	public bool timerRunning = false;
	int i;

	public Text tersUIText;

	// Use this for initialization
	void Start () {
		timerRunning = false;
		ss = GameObject.Find ("Snake").GetComponent<SnakeScript> ();
		DestroyGameObject_script = GameObject.Find ("Bodypart").GetComponent<DestroyGameObject> ();
	}

	// Update is called once per frame
	void Update () {
		GameObject[] Tersler;
		Tersler = GameObject.FindGameObjectsWithTag("ters");
		foreach (GameObject item in Tersler) {
			if ((item.transform.position - transform.position).magnitude < 1.3f) {
				Destroy (item);
				sn.tersSayisi--;
				timerRunning = true;
				ss.ters = true;
				tenSec = 10;
				sn.GenerateRandomObjectTers(1);
			}
		}
		if(timerRunning){
			tenSec -= Time.smoothDeltaTime;
			if(tenSec >= 0){
				tersUIText.text = "REVERSE "+tenSec.ToString().Substring(0,3)+" SEC";
			}else{
				tersUIText.text = "";
				timerRunning = false;
				ss.ters = false;
			}
		}
	}
}
