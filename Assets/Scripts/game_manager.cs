using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour {

	public int lives;
	public int score;
	public int waves;
	public int cash;

	public Text livesText;
	public Text scoreText;
	public Text wavesText;
	public Text goScoreText;
	public Text goWavesText;
	public Text cashText;
	public Text countdownText;
	public int difficulty;

	public enemy_spawning spawner;

	public bool newHighScore;
	public int slimeBabiesAlive;

	// Use this for initialization
	void Start () {
		//lives = 10;
		score = 0;
		waves = 4;
		//cash = 300;
		slimeBabiesAlive = 0;
		newHighScore = false;

		StartCountDown ();
		getDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void getDifficulty(){
		difficulty = PlayerPrefs.GetInt ("diff",0);
	}
	public void AddCash(int amt) {
		cash += amt;
		cashText.text = "Cash: " + System.Convert.ToString (cash);
	}

    public void SubCash(int amt)
    {
        if (amt <= cash) {
            cash -= amt;
            cashText.text = "Cash: " + System.Convert.ToString(cash);
        }
	}

	public void AddScore(int amt) {
		score += amt;
		scoreText.text = "Score: " + System.Convert.ToString (score);
		goScoreText.text = scoreText.text;
	}

	public bool CheckEnemiesAlive(int type) {
		int alive = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enem in enemies) {
			if (enem.GetComponent<enemy_movement> ().isDying) {
				alive -= 1;
				Debug.Log ("RUN??");
			}
		}

		Debug.Log (alive);

		if (waves != 5) {
			if (alive == 0 && spawner.allEnemiesSpawned) {
				return false;
			} else {
				return true;
			}
		} else {
			if (spawner.allEnemiesSpawned && slimeBabiesAlive == 0) {
				return false;
			} else {
				return true;
			}
		}
	}
	public void setEasy(){
		difficulty = 8;
	}
	public void setMed(){

	}
	public void setHard(){

	}
	public void StartCountDown() {
		Debug.Log ("call");
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject blt in bullets) {
			Destroy (blt);
		}

		countdownText.enabled = true;
		StartCoroutine (WaitForWave (1));
	}

	private IEnumerator WaitForWave(float time) {
		for (int i = 5; i > 0; i--) {
			countdownText.text = System.Convert.ToString (i);
			yield return new WaitForSeconds (time);
		}
		countdownText.enabled = false;
		waves += 1;
		wavesText.text = "- Wave " + System.Convert.ToString (waves) + " -";
		goWavesText.text = "Waves: " + System.Convert.ToString (waves);
		wavesText.gameObject.GetComponent<Animation> ().Play ();
		yield return new WaitForSeconds (time);
		spawner.allEnemiesSpawned = false;
		spawner.enemiesToSpawn = 10;
	}

	public void GameOver() {
		GameObject.Find ("GameOver_Text").GetComponent<Animation> ().Play ();
		GameObject.Find ("Score_Back").GetComponent<RawImage> ().enabled = false;
		GameObject.Find ("Lives_Cash_Back").GetComponent<RawImage> ().enabled = false;
		GameObject.Find ("Heart").SetActive (false);
		GameObject.Find ("Money").SetActive (false);

		scoreText.enabled = false;
		livesText.enabled = false;
		cashText.enabled = false;
		spawner.allEnemiesSpawned = true;

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enem in enemies) {
			enem.GetComponent<enemy_movement> ().enabled = false;
		}

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Tower");
		foreach (GameObject twr in towers) {
			Destroy (twr);
		}
			
		StartCoroutine (GetComponent<game_over> ().getHsFromDb ());
	}

	public void Retry() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

		if (newHighScore) {
			StartCoroutine (GetComponent <game_over> ().addHsToDb ());
		}
	}

	public void BackToMain() {
		SceneManager.LoadScene ("menu");

		if (newHighScore) {
			StartCoroutine (GetComponent <game_over> ().addHsToDb ());
		}
	}
}
