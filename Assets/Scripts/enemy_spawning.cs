using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawning : MonoBehaviour {

	public GameObject enemy;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpwan) {
			nextSpwan = Time.time + spawnRate;
			whereToSpawn = gameObject.transform.position;
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}
	}
}
