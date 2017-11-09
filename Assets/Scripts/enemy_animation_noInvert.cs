using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_animation_noInvert: MonoBehaviour {

	public Vector2[] movePositions = new Vector2[5];
	public Vector2 movePositions2;
	Animator anim;

	private game_manager gm;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
			gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
			if (gm.waves == 4 || gm.waves == 5) {
				Vector3 theScale = transform.localScale;
				theScale.x = theScale.x * -1;
				transform.localScale = theScale;
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (SceneManager.GetActiveScene ().name.Equals ("map1_master")) {
			if (transform.position.x == movePositions [0].x &&
			    transform.position.y == movePositions [0].y) {
				Vector3 theScale = transform.localScale;
				theScale.x = theScale.x * -1;
				transform.localScale = theScale;
			}
			if (transform.position.x == movePositions [1].x &&
			    transform.position.y == movePositions [1].y) {
				Vector3 theScale = transform.localScale;
				theScale.x = theScale.x * -1;
				transform.localScale = theScale;
			}
			if (transform.position.x == movePositions [2].x &&
			    transform.position.y == movePositions [2].y) {
				Vector3 theScale = transform.localScale;
				theScale.x = theScale.x * -1;
				transform.localScale = theScale;
			}
			if (transform.position.x == movePositions [3].x &&
			    transform.position.y == movePositions [3].y) {
				Vector3 theScale = transform.localScale;
				theScale.x = theScale.x * -1;
				transform.localScale = theScale;
			}
			if (transform.position.x == movePositions [4].x &&
			    transform.position.y == movePositions [4].y && anim.GetInteger ("state") == 0) {
				anim.SetInteger ("state", 2);
				Destroy (this.gameObject, anim.GetCurrentAnimatorStateInfo (0).length);

				if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
					if (!gm.CheckEnemiesAlive (2)) {
						gm.StartCountDown ();
					}
				}
			}
		} else if (SceneManager.GetActiveScene ().name.Equals ("map2_master")) {
			if (transform.position.x == movePositions2.x &&
				transform.position.y == movePositions2.y && anim.GetInteger("state") == 0) {
				anim.SetInteger ("state", 2);
				Destroy (this.gameObject, anim.GetCurrentAnimatorStateInfo (0).length);

				if (!SceneManager.GetActiveScene ().name.Equals ("menu")) {
					if (!gm.CheckEnemiesAlive (2)) {
						gm.StartCountDown ();
					}
				}
			}
		}
	}
}
