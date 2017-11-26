using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour {

	private float hs_blink;
	public Text hs_text;
	private game_manager gm;

	public Text hs_name;
	public Animation hs_anim;

	private int[] scores;	// Array containing only hs from db
	private int[] newScores;	// Array containing new player hs
	private int rank;

	// Use this for initialization
	void Start () {
		gm = gameObject.GetComponent<game_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		// blinks the new high score thing
		hs_blink += Time.deltaTime;
		if (hs_blink > 0.5f && hs_blink < 1.0f) {
			hs_text.color = Color.red;
		} else if (hs_blink >= 1.0f && hs_blink < 1.5f) {
			hs_text.color = Color.yellow;
		} else if (hs_blink >= 1.5f) {
			hs_blink = 0.25f;
		}
	}

	public IEnumerator getHsFromDb()
	{
		string[] users;
		string[] fields = {"Name: ", "Score: "};
		string address;

		#if UNITY_EDITOR
			address = "http://localhost/dotf/geths.php";
		#else
			address = "http://192.168.0.10/dotf/geths.php";
		#endif

		WWW hs = new WWW ("http://192.168.0.10/dotf/geths.php");

		yield return hs;

		if (hs.error != null) {
			UnityEngine.Debug.Log(hs.error);
		}

		string hsString = hs.text;
		//Debug.Log (hsString);

		// Dynamically place strings in array separated by ";" from PHP data file
		users = hsString.Split (';');
		scores = new int[users.Length];

		// Loop for each user, for each field
		for (int k = 0; k < users.Length - 1; k++) {
			for (int i = 0; i < fields.Length; i++) {
				string value = getDataValue (users [k], fields [i]);
				//Debug.Log (value);

				if (i == 1) {
					scores [k] = System.Convert.ToInt32 (value);
				}
			}
			//Debug.Log ("------------");
		}

		sort (scores);

		// If the user score is greater than the top 10 scores from the db, then create a new array and sort that 
		// and see where in the array it places to get the rank
		if (checkNewHs ()) {
			GameObject.Find ("not_hs").SetActive (false);

			ArrayList tmpArray = new ArrayList ();
			for (int j = 0; j < scores.Length - 1; j++) {
				tmpArray.Add (scores [j]);
			}

			tmpArray.Add (gm.score);

			newScores = new int[tmpArray.Count];
			for (int m = 0; m < newScores.Length; m++) {
				newScores [m] = System.Convert.ToInt32 (tmpArray [m]);
			}

			sort (newScores);
			rank = getRank (newScores, gm.score);

			hs_anim.Play ("new_hs");
		}
	}

	// Bubble sort
	private void sort(int[] arr) {
		for(int x = 0; x < arr.Length; x++)
		{
			for(int y = 0; y < arr.Length - 1; y++)
			{
				if (arr[y] < arr[y+1])
				{
					int temp = arr[y+1];
					arr[y+1] = arr[y];
					arr[y] = temp;
				}
			}
		}
	}

	private int getRank(int[] arr, int key) {
		for (int i = 0; i < arr.Length; i++) {
			if (arr [i] == key) {
				int tmp = i + 1;
				GameObject.Find ("rank").GetComponent<Text> ().text = "Rank " + System.Convert.ToString (tmp);
				return tmp;
			}
		}
		return 0;
	}

	private bool checkNewHs() {
		for (int i = 0; i < 10; i++) {
			if (gm.score > scores [i]) {
				gm.newHighScore = true;
				return true;
			}
		}
		return false;
	}

	// Return data values from Users fields
	private string getDataValue(string data, string index) {
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if (value.Contains("|"))
			value = value.Remove(value.IndexOf("|"));
		return value;
	}

	public IEnumerator addHsToDb()
	{
		string post_url;
		#if UNITY_EDITOR
		post_url = "http://192.168.0.10/dotf/addhs.php?" + "&name=" + ((hs_name.text!="") ? hs_name.text : "xxx") + "&score=" + System.Convert.ToString(gm.score);
		#else
		post_url = "http://192.168.0.10/dotf/addhs.php?" + "&name=" + ((hs_name.text!="") ? hs_name.text : "xxx") + "&score=" + System.Convert.ToString(gm.score);
		#endif

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null)
		{
			Debug.Log("There was an error adding the highscore: " + hs_post.error);
		}
	}
}
