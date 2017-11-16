﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehaviour : MonoBehaviour {
    public float speed = 10;
    public int damage;
    public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;
    private float distance;
    private float startTime;
	private game_manager gm;

    // Use this for initialization
    void Start () {
		startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);

		if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
			gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
		}
    }

    private void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
		if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
				if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
					Transform healthBarTransform = target.transform.Find ("HealthBar");
					HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
					healthBar.Damage (30);
					gm.AddScore (7);
				
					if (healthBar.GetHealth () <= 0) {
						healthBar.SetHealth (0);
						target.GetComponent<BoxCollider2D> ().isTrigger = false;
						target.GetComponent<enemy_movement> ().stopMove = 1;
						target.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
						target.GetComponent<Animator> ().SetInteger ("state", 2);
						Destroy (target, target.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
						gm.AddCash (5);

						if (target.name.Equals ("enemy6(Clone)")) {
							gm.slimeBabiesAlive -= 1;
						}

						if (!gm.CheckEnemiesAlive (1)) {
							gm.StartCountDown ();
						}
					}
				}
            }
            Destroy(gameObject);
        }
    }
    // 1 
    
	
	// Update is called once per frame
	/*void FixedUpdate () {
        float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector2.MoveTowards (startPosition, targetPosition, timeInterval * speed / distance);
        
		if (gameObject.transform.position.x == targetPosition.x) 
        {
            if (target != null)
            {
            }
            Destroy(gameObject);
        }
    }*/
}
