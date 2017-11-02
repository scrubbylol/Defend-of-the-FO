using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	private float maxHealth = 50;
	private float currentHealth = 50;
	private float originalScale;
	private game_manager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<game_manager> ();
		originalScale = gameObject.transform.localScale.x;
		maxHealth = maxHealth + (gm.waves * 50);
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
