using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	private float maxHealth = 50;
	public float currentHealth = 50;
	private float originalScale;
	private game_manager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
		originalScale = gameObject.transform.localScale.x;
		if (gm.waves == 1) {
			maxHealth = 100;
		} else if (gm.waves == 2) {
			maxHealth = 150;
		} else if (gm.waves == 3) {
			maxHealth = 250;
		} else if (gm.waves == 4) {
			maxHealth = 300;
		} else if (gm.waves == 5) {
			maxHealth = 400;
			if (gameObject.name.Equals ("enemy6(Clone)")) {
				maxHealth = 100;
			}
		} else if (gm.waves == 6) {
			maxHealth = 350;
		} else {
			maxHealth = 400;
		}
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = currentHealth / maxHealth * originalScale;
		gameObject.transform.localScale = tmpScale;*/
	}

	public void Damage(int dmg) {
		currentHealth -= dmg;
		UpdateHealthUI ();
	}

	public void SetHealth(float health) {
		this.currentHealth = health;
		UpdateHealthUI ();
	}

	public float GetHealth() {
		return this.currentHealth;
	}

	public void UpdateHealthUI() {
		Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = currentHealth / maxHealth * originalScale;
		gameObject.transform.localScale = tmpScale;
	}
}
