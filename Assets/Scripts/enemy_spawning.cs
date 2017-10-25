using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	public int enemiesToSpawn;

	public bool allEnemiesSpawned;

	private game_manager gm;

	// Use this for initialization
	void Start () {
		allEnemiesSpawned = false;
		enemiesToSpawn = 10;
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpwan && enemiesToSpawn > 0 && !allEnemiesSpawned) {
			nextSpwan = Time.time + spawnRate;
			whereToSpawn = gameObject.transform.position;
			if (gm.waves % 2 == 0) {
				Instantiate (enemy2, whereToSpawn, Quaternion.identity);
			} else {
				Instantiate (enemy1, whereToSpawn, Quaternion.identity);
			}
			enemiesToSpawn -= 1;

			if (enemiesToSpawn == 0) {
				allEnemiesSpawned = true;
			}
		}
	}
}
