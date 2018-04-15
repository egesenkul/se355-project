using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyGameObject : MonoBehaviour {
	public SnakeScript snake_script;
	public int i = 0;
	public int score=0;
	public int highScore;

	public Text scoreUI;

	public RandomCreateObject sn;
	// Use this for initialization
	void Start () {
		snake_script = GameObject.Find ("Snake").GetComponent<SnakeScript> ();
		highScore = PlayerPrefs.GetInt ("HighScore");
		scoreUI.text = "Score: "+score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] Cubeler;
		Cubeler = GameObject.FindGameObjectsWithTag("Cube");
		foreach (GameObject item in Cubeler) {
			if ((item.transform.position - transform.position).magnitude < 1.5f) {
				Destroy (item);
				score++;
				scoreUI.text = "Score: "+score.ToString ();
				if (score > highScore) {
					PlayerPrefs.SetInt ("HighScore", score);
				}
				snake_script.speed += 0.25f;
				sn.GenerateRandomObject(1);
				if (i < 2) {
					i++;
					snake_script.AddBodyPart ();
				}
			}
		}
	}

}
