using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {

	public float speed = 5f;

	public Vector2[] movePositions = new Vector2[12];

    private int currentWaypoint = 0;
    private game_manager gm;

	Animator anim;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<game_manager>();

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		Vector2 nextPosition = movePositions [0];
		transform.position = Vector2.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);

		if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y) {
			for (int i = 0; i < movePositions.Length-1; i++) {
				movePositions [i] = movePositions [i + 1];
                currentWaypoint++;

            }
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("End")) {
			if (gm.lives > 0) {
				gm.lives -= 1;
				gm.livesText.text = "Lives: " + System.Convert.ToString (gm.lives);

				if (gm.lives == 0) {
					gameOver ();
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
