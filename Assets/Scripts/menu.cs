using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	public GameObject enemy;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	private int selectedMap;

	// Use this for initialization
	void Start () {
		selectedMap = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Spawn enemies
		if (Time.time > nextSpwan) {
			nextSpwan = Time.time + spawnRate;
			whereToSpawn = gameObject.transform.position;
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}
	}

	public void MapSelect() {
		//SceneManager.LoadScene ("map1_master");
		GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_out");
		GameObject.Find("Map_Canvas").GetComponent<Animation>().Play("map_canvas_in");
	}

	public void ClickMap(int map) {
		if (map == 1) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = true;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = false;
		} else if (map == 2) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = true;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = false;
		} else if (map == 3) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = true;
		}

		selectedMap = map;
	}

	public void Back(int back) {
		if (back == 1) {
			GameObject.Find("Map_Canvas").GetComponent<Animation>().Play("map_canvas_out");
			GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_in");
		}
	}

	public void StartGame() {
		if (selectedMap == 1) {
			SceneManager.LoadScene ("map1_master");
		} else if (selectedMap == 2) {
			SceneManager.LoadScene ("map2_master");
		}
	}

	public void EndGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
