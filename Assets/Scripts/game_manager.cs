using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

	public int lives;
	public int score;
	public int waves;
	public int cash;

	public Text livesText;
	public Text scoreText;
	public Text wavesText;
	public Text cashText;
	public Text countdownText;

	public enemy_spawning spawner;

	// Use this for initialization
	void Start () {
		lives = 10;
		score = 0;
		waves = 1;
		cash = 50;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddCash(int amt) {
		cash += amt;
		cashText.text = "Cash: " + System.Convert.ToString (cash);
	}

	public void SubCash(int amt) {
		cash -= amt;
		cashText.text = "Cash: " + System.Convert.ToString (cash);
	}

	public void AddScore(int amt) {
		score += amt;
		scoreText.text = "Score: " + System.Convert.ToString (score);
	}

	public bool CheckEnemiesAlive(int type) {
		if (type == 1) {
			if (GameObject.FindGameObjectsWithTag ("Enemy").Length - 1 == 0 && spawner.allEnemiesSpawned) {
				return false;
			} else {
				return true;
			}
		} else {
			if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0 && spawner.allEnemiesSpawned) {
				return false;
			} else {
				return true;
			}
		}
	}

	public void StartCountDown() {
		countdownText.enabled = true;
		StartCoroutine (WaitForWave (1));
	}

	private IEnumerator WaitForWave(float time) {
		for (int i = 5; i > 0; i--) {
			countdownText.text = System.Convert.ToString (i);
			yield return new WaitForSeconds (time);
		}

		countdownText.enabled = false;
		yield return new WaitForSeconds (time);

		waves += 1;
		wavesText.text = "- Wave " + System.Convert.ToString (waves) + " -";
		wavesText.gameObject.GetComponent<Animation> ().Play ();

		spawner.allEnemiesSpawned = false;
		spawner.enemiesToSpawn = 10;
	}
}
