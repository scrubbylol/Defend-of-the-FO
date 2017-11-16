﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_behavior : MonoBehaviour {

	// Use this for initialization
	private int isDamaged = 0;
	private Animator anim;
	private HealthBar healthBar;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform healthBarTransform = transform.Find ("HealthBar");
		healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();
		if (isDamaged == 0) {
			if (healthBar.currentHealth < 100) {
				gameObject.GetComponent<enemy_movement> ().speed = 3;
				anim.SetInteger ("state", 1);
				isDamaged = 1;
			}
		}
	}
}
