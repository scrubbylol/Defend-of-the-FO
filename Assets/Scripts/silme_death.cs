using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silme_death : MonoBehaviour {

	// Use this for initialization
	public GameObject enemy6;
	Vector2 whereToSpawn;
	int spawned = 0;
	int moveState;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform healthBarTransform = transform.Find ("HealthBar");
		HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
		if (healthBar.GetHealth () <= 0) {
			if (spawned == 0) {
				moveState = GetComponent<enemy_movement>().nextMove;
				enemy6.gameObject.GetComponent<enemy_movement> ().nextMove = moveState;
				Instantiate (enemy6, gameObject.transform.position, Quaternion.identity);
				spawned = 1;
			}
		}
	}
}
