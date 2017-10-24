using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_desturctio_delegate : MonoBehaviour {
	public delegate void EnemyDelegate (GameObject enemy);
	public EnemyDelegate enemyDelegate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDestroy () {
		if (enemyDelegate != null) {
			enemyDelegate (gameObject);
		}
	}
}
