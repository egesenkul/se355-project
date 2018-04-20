using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mayinScript : MonoBehaviour {

	public DestroyGameObject DestroyGameObject_script;
	public RandomCreateObject sn;
	public GameObject gameOverMenuUI;

	public Text HighS;
	public Text Score;
	public Text oyunSkoru;

	private bool setNewScore=true;
	public bool GameStop=false;
	// Use this for initialization
	void Start () {
		DestroyGameObject_script = GameObject.Find ("Bodypart").GetComponent<DestroyGameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] Mayinlar;
		Mayinlar = GameObject.FindGameObjectsWithTag("mayin");
		foreach (GameObject item in Mayinlar) {
			if ((item.transform.position - transform.position).magnitude < 1.45f) {
				Destroy (item);
				GameStop = true;
				Handheld.Vibrate ();
				gameOverMenuUI.SetActive (true);
				Score.text = "Score: "+DestroyGameObject_script.score;
				HighS.text = "High Score: "+PlayerPrefs.GetInt ("HighScore").ToString();
				if (DestroyGameObject_script.score > PlayerPrefs.GetInt ("HighScore") && setNewScore) {
					PlayerPrefs.SetInt ("HighScore", DestroyGameObject_script.score);
					setNewScore = false;
				}
			}
		}
		if (GameStop) {
			Time.timeScale = 0.0f;
		}
	}
}
