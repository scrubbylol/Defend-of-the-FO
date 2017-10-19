using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_animation: MonoBehaviour {

	public Vector2[] movePositions = new Vector2[5];
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x == movePositions[0].x &&
			transform.position.y == movePositions[0].y) {
			anim.SetInteger ("state", 1);
		}
		if (transform.position.x == movePositions[1].x &&
			transform.position.y == movePositions[1].y) {
			anim.SetInteger ("state", 0);
		}
		if (transform.position.x == movePositions[2].x &&
			transform.position.y == movePositions[2].y) {
			anim.SetInteger ("state", 1);
		}
		if (transform.position.x == movePositions[3].x &&
			transform.position.y == movePositions[3].y) {
			anim.SetInteger ("state", 0);
		}
		if (transform.position.x == movePositions[4].x &&
			transform.position.y == movePositions[4].y) {
		    anim.SetInteger ("state", 2);
			Destroy (this.gameObject,anim.GetCurrentAnimatorStateInfo(0).length);
		}
	}
}
