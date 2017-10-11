using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spwaning : MonoBehaviour {

	public GameObject enemy;
	Vector2 whereToSpwan;
	public float spwanRate = 2f;
	float nextSpwan = 0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpwan) {
			nextSpwan = Time.time + spwanRate;
			whereToSpwan = gameObject.transform.position;
			Instantiate (enemy, whereToSpwan, Quaternion.identity);
		}
	}

}
