using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	public GameObject enemy;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpwan = 0.0f;

	private string[] names;
	private int[] scores;

	private int selectedMap;

	// Use this for initialization
	void Start () {
		selectedMap = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Spawn enemies
		if (Time.time > nextSpwan) {
			nextSpwan = Time.time + spawnRate;
			whereToSpawn = gameObject.transform.position;
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}
	}

	public void MapSelect() {
		GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_out");
		GameObject.Find("Map_Canvas").GetComponent<Animation>().Play("map_canvas_in");
		GameObject.Find ("Start").GetComponent<Button> ().enabled = true;
		GameObject.Find ("Map_Back").GetComponent<Button> ().enabled = true;
	}

	public void HighScores() {
		GameObject.Find("Hs_Canvas").GetComponent<Animation>().Play("hs_canvas_in");
		GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_out");
		GameObject.Find ("Start").GetComponent<Button> ().enabled = true;
		GameObject.Find ("Hs_Back").GetComponent<Button> ().enabled = true;

		StartCoroutine (getHsFromDb ());
	}

	IEnumerator getHsFromDb()
	{
		string[] users;
		string[] fields = {"Name: ", "Score: "};
		string address;

		#if UNITY_EDITOR
			address = "http://localhost/dotf/geths.php";
		#else
			address = "http://192.168.0.10/dotf/geths.php";
		#endif

		WWW hs = new WWW (address);

		yield return hs;

		if (hs.error != null) {
			Debug.Log(hs.error);
		}

		string hsString = hs.text;
		//Debug.Log (hsString);

		// Dynamically place strings in array separated by ";" from PHP data file
		users = hsString.Split (';');
		names = new string[users.Length];
		scores = new int[users.Length];

		for (int i = 0; i < 10; i++) {
			scores [i] = 0;
		}

		// Loop for each user, for each field
		for (int k = 0; k < users.Length - 1; k++) {
			for (int i = 0; i < fields.Length; i++) {
				string value = getDataValue (users [k], fields [i]);
				//Debug.Log (value);

				if (i == 0) {
					names [k] = value;
				} else if (i == 1) {
					scores [k] = System.Convert.ToInt32 (value);
				}
			}
			//Debug.Log ("------------");
		}

		sort ();

		GameObject.Find("Name_Body").GetComponent<Text> ().text =  "";
		GameObject.Find("Score_Body").GetComponent<Text> ().text =  "";

		for (int i = 0; i < 10; i++) {
			if (names [i] != null) {
				GameObject.Find ("Name_Body").GetComponent<Text> ().text += names [i] + ((i!=9) ? "\n" : "");
			} else {
				GameObject.Find ("Name_Body").GetComponent<Text> ().text += "xxx" + ((i!=9) ? "\n" : "");
			}

			if (i != 10) {

			}

			GameObject.Find ("Score_Body").GetComponent<Text> ().text += scores[i] + ((i!=9) ? "\n" : "");
		}
	}

	// Bubble sort
	private void sort() {
		for(int x = 0; x < scores.Length; x++)
		{
			for(int y = 0; y<scores.Length - 1; y++)
			{
				if (scores[y] < scores[y+1])
				{
					int temp = scores[y+1];
					string temp2 = names[y+1];
					scores[y+1] = scores[y];
					scores[y] = temp;

					names [y+1] = names [y];
					names [y] = temp2;
				}
			}
		}

		for (int z = 0; z < scores.Length; z++) {
			//Debug.Log (scores [z]);
			//Debug.Log (names [z]);
		}
	}

	// Return data values from Users fields
	private string getDataValue(string data, string index) {
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if (value.Contains("|"))
			value = value.Remove(value.IndexOf("|"));
		return value;
	}

	public void ClickMap(int map) {
		if (map == 1) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = true;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = false;
		} else if (map == 2) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = true;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = false;
		} else if (map == 3) {
			GameObject.Find ("Map1_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map2_Select").GetComponent<RawImage> ().enabled = false;
			GameObject.Find ("Map3_Select").GetComponent<RawImage> ().enabled = true;
		}

		selectedMap = map;
	}

	public void Back(int back) {
		if (back == 1) {
			GameObject.Find("Map_Canvas").GetComponent<Animation>().Play("map_canvas_out");
			GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_in");
			GameObject.Find ("Start").GetComponent<Button> ().enabled = false;
			GameObject.Find ("Map_Back").GetComponent<Button> ().enabled = false;
		} else if (back == 2) {
			GameObject.Find("Hs_Canvas").GetComponent<Animation>().Play("hs_canvas_out");
			GameObject.Find("Main_Canvas").GetComponent<Animation>().Play("main_canvas_in");
			GameObject.Find ("Start").GetComponent<Button> ().enabled = false;
			GameObject.Find ("Hs_Back").GetComponent<Button> ().enabled = false;
		}
	}

	public void StartGame() {
		if (selectedMap == 1) {
			SceneManager.LoadScene ("map1_master");
		} else if (selectedMap == 2) {
			SceneManager.LoadScene ("map2_master");
		}
	}

	public void EndGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
