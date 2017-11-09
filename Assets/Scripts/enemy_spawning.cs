using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	public int enemiesToSpawn;

	public bool allEnemiesSpawned;

	private game_manager gm;

	// Use this for initialization
	void Start () {
		allEnemiesSpawned = false;
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpwan && enemiesToSpawn > 0 && !allEnemiesSpawned) {
			nextSpwan = Time.time + spawnRate;
			whereToSpawn = gameObject.transform.position;
			if (gm.waves == 1) {
				Instantiate (enemy1, whereToSpawn, Quaternion.identity);
			} else if (gm.waves == 2) {
				Instantiate (enemy2, whereToSpawn, Quaternion.identity);
			} else if (gm.waves == 3) {
				Instantiate (enemy3, whereToSpawn, Quaternion.identity);
			} else if (gm.waves == 4) {
				Instantiate (enemy4, whereToSpawn, Quaternion.identity);
			} else {
				Instantiate (enemy5, whereToSpawn, Quaternion.identity);
			}

			/*if (gm.waves % 2 == 0) {
				Instantiate (enemy2, whereToSpawn, Quaternion.identity);
			} else {
				Instantiate (enemy1, whereToSpawn, Quaternion.identity);
			}*/
			enemiesToSpawn -= 1;

			if (enemiesToSpawn == 0) {
				allEnemiesSpawned = true;
			}
		}
	}
}

