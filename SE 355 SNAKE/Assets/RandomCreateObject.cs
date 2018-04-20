using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreateObject : MonoBehaviour {

	public Vector3 center;
	public Vector3 size;

	GameObject player;

	public GameObject mayin;
	public GameObject bonus;
	public GameObject ters;

	public int tersSayisi = 0;
	public int mayinSayisi = 0;
	public	int	bonusSayisi = 0;

	// Use this for initialization
	void Start () {
		size = new Vector3 (10, 10, 10);
		player = GameObject.Find ("Snake");;
		GenerateRandomObjectCube (10);
		GenerateRandomObjectMayin (4);
		GenerateRandomObjectTers (2);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			GenerateRandomObjectCube (1);
		}
		if(Input.GetKeyDown(KeyCode.E)){
			GenerateRandomObjectMayin (1);
		}
		if (bonusSayisi == 0) {
			GenerateRandomObjectCube(1);
		}
		if (mayinSayisi == 0) {
			GenerateRandomObjectMayin(1);
		}
		if (tersSayisi == 0) {
			GenerateRandomObjectTers(1);
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
				mayinSayisi++;
			}
		}
	}

	public void GenerateRandomObjectTers(int i){
		for (int j = 0; j < i; j++) {
			Vector3 pos = new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));
			if ((player.transform.position - pos).magnitude > 0.5f && CubeMesafeKontrol(pos)) {
				GameObject cube = Instantiate(ters);
				cube.tag = "ters";
				cube.transform.position = pos;
				cube.AddComponent<Rigidbody> ();
				cube.AddComponent<GravityReciever> ();
				tersSayisi++;
			}
		}
	}

	public void GenerateRandomObjectCube(int i){
		for (int j = 0; j < i; j++) {
			Vector3 pos = new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));
			if ((player.transform.position - pos).magnitude > 0.5f && CubeMesafeKontrol(pos) && MayinMesafeKontrol(pos) && TersMesafeKontrol(pos)) {
				GameObject cube = Instantiate(bonus);
				cube.tag = "Cube";
				cube.transform.position = pos;
				cube.AddComponent<Rigidbody> ();
				cube.AddComponent<GravityReciever> ();
				bonusSayisi++;
			}
		}
	}

	public bool CubeMesafeKontrol(Vector3 position){
		GameObject[] Cubeler;
		Cubeler = GameObject.FindGameObjectsWithTag("Cube");
		foreach (GameObject item in Cubeler) {
			if ((item.transform.position - position).magnitude < 2) {
				return false;
			}
		}
		return true;
	}

	public bool MayinMesafeKontrol(Vector3 position){
		GameObject[] Mayinlar;
		Mayinlar = GameObject.FindGameObjectsWithTag("mayin");
		foreach (GameObject item in Mayinlar) {
			if ((item.transform.position - position).magnitude < 4) {
				return false;
			}
		}
		return true;
	}

	public bool TersMesafeKontrol(Vector3 position){
		GameObject[] Tersler;
		Tersler = GameObject.FindGameObjectsWithTag("ters");
		foreach (GameObject item in Tersler) {
			if ((item.transform.position - position).magnitude < 2) {
				return false;
			}
		}
		return true;
	}

}
