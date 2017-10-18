using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

	public int lives;
	public int score;
	public int waves;

	public Text livesText;
	public Text scoreText;
	public Text wavesText;

	// Use this for initialization
	void Start () {
		lives = 10;
		score = 0;
		waves = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
