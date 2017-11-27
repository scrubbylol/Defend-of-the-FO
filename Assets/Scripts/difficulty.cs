using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour {

	// Use this for initialization
	public void SetDif (int mode) {
		Debug.Log ("diffculty set");
		Debug.Log (mode);
		PlayerPrefs.SetInt ("diff", mode);
	}
}
