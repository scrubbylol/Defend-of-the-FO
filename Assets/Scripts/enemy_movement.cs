﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_movement : MonoBehaviour {

	public float speed = 5f;

	public Vector2[] movePositions = new Vector2[12];
	public Vector2[] movePositions2 = new Vector2[5];

    private int currentWaypoint = 0;
	public int nextMove = 0;
    private game_manager gm;
	public int stopMove = 0;
	public int moveState = 0;

	Animator anim;

	// Use this for initialization
	void Start () {
		if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
			gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
		}

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame

	void FixedUpdate () {
		if (SceneManager.GetActiveScene ().name.Equals ("map1_master") || SceneManager.GetActiveScene().name.Equals("menu")) {
			Vector2 nextPosition;
			string name = gameObject.name;
			if (name == "enemy6(Clone)") {
				Debug.Log (nextMove);
				nextPosition = movePositions [nextMove];
			} else {
				nextPosition = movePositions [0];
			}
			if (stopMove == 0) {
				transform.position = Vector2.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);
				if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y){
					if (name != "enemy6(Clone)") {
						nextMove++;
					}
					for (int i = 0; i < movePositions.Length - 1; i++) {
						movePositions [i] = movePositions [i + 1];
						currentWaypoint++;
					}
				}
			}
		} else if (SceneManager.GetActiveScene ().name.Equals ("map2_master")) {
			Vector2 nextPosition = movePositions2 [0];
			if (stopMove == 0) {
				transform.position = Vector2.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);
				if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y) {
					for (int i = 0; i < movePositions2.Length - 1; i++) {
						movePositions2 [i] = movePositions2 [i + 1];
						currentWaypoint++;

					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
			if (col.gameObject.tag.Equals ("End")) {
				if (gm.lives > 0) {
					GetComponent<BoxCollider2D> ().isTrigger = false;
					gm.lives -= 1;
					gm.livesText.text = "Lives: " + System.Convert.ToString (gm.lives);

					if (gm.lives == 0) {
						gameOver ();
					}
				}
			}
		}
	}

	void gameOver() {
		GameObject.Find ("GameOver_Text").GetComponent<Animation> ().Play ();
	}

    public float distanceToGoal()
    {
        float distance = 10;
        /*distance += Vector3.Distance(
            gameObject.transform.position,
            movePositions[currentWaypoint]);
        for (int i = currentWaypoint; i < movePositions.Length - 1; i++)
        {
            Vector3 startPosition = movePositions[i];
            Vector3 endPosition = movePositions[i + 1];
            distance += Vector3.Distance(startPosition, endPosition);
        }*/
        return distance;
    }
}
