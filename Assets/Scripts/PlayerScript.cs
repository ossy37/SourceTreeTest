using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  ////ここを追加したよ////

public class PlayerScript : MonoBehaviour {

	public int score = 0; ////ここを追加したよ////

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<Text>().text = "点数" + score.ToString() + "点";////ここを追加したよ////

	}
}
