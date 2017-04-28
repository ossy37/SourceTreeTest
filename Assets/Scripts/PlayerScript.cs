using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public int score = 0;
	bool flag = false; ////ここを追加したよ////

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (flag == true) { ////ここを追加したよ////
			this.GetComponent<Text> ().text = "点数" + score.ToString () + "点";////ここを追加したよ////
		} ////ここを追加したよ////

	}
}
