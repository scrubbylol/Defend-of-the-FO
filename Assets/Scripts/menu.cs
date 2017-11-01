using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
	public GameObject enemy;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	// Use this for initialization
	void Start () {
		
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

	public void StartGame() {
		SceneManager.LoadScene ("map1_master");
	}

	public void EndGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
