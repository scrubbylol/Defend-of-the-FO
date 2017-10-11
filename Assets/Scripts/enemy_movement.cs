using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {

	public float speed = 5f;

	public Vector2[] movePositions = new Vector2[5];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		Vector2 nextPosition = movePositions [0];
		transform.position = Vector2.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);

		if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y) {
			for (int i = 0; i < movePositions.Length-1; i++) {
				movePositions [i] = movePositions [i + 1];
			}
		}

		if (transform.position.x == movePositions[movePositions.Length-1].x &&
			transform.position.y == movePositions[movePositions.Length-1].y) {
			Destroy (this.gameObject);
		}
	}
}
