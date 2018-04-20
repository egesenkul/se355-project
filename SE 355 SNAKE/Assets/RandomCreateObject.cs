using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreateObject : MonoBehaviour {

	public Vector3 center;
	public Vector3 size;

	GameObject player;
	public GameObject mayin;
	public GameObject bonus;

	// Use this for initialization
	void Start () {
		size = new Vector3 (10, 10, 10);
		player = GameObject.Find ("Snake");;
		GenerateRandomObjectCube (10);
		GenerateRandomObjectMayin (4);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			GenerateRandomObjectCube (1);
		}
		if(Input.GetKeyDown(KeyCode.E)){
			GenerateRandomObjectMayin (1);
		}
	}

	public void GenerateRandomObjectMayin(int i){
		for (int j = 0; j < i; j++) {
			Vector3 pos = new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));
			if ((player.transform.position - pos).magnitude > 0.5f && CubeMesafeKontrol(pos)) {
				GameObject cube = Instantiate(mayin);
				cube.tag = "mayin";
				cube.transform.position = pos;
				cube.AddComponent<Rigidbody> ();
				cube.AddComponent<GravityReciever> ();
				Debug.Log (cube.transform.position);
			}
		}
	}

	public void GenerateRandomObjectCube(int i){
		for (int j = 0; j < i; j++) {
			Vector3 pos = new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));
			if ((player.transform.position - pos).magnitude > 0.5f && CubeMesafeKontrol(pos)) {
				GameObject cube = Instantiate(bonus);
				cube.tag = "Cube";
				cube.transform.position = pos;
				cube.AddComponent<Rigidbody> ();
				cube.AddComponent<GravityReciever> ();
				Debug.Log (cube.transform.position);
			}
		}
	}

	public bool CubeMesafeKontrol(Vector3 position){
		GameObject[] Cubeler;
		Cubeler = GameObject.FindGameObjectsWithTag("Cube");
		foreach (GameObject item in Cubeler) {
			if ((item.transform.position - position).magnitude < 2.6f) {
				return false;
			}
		}
		return true;
	}

}
