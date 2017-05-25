using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	public float ScoreOfPlayer;





	public GameObject Room1Wall;
	//public GameObject Room2Wall;
	//public GameObject Room3Wall;
	//public GameObject Room4Wall;
	//public GameObject Room5Wall;






	// Use this for initialization
	void Start () {
		ScoreOfPlayer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreOfPlayer == 3) {
			Destroy (Room1Wall);
		} /*else if (ScoreOfPlayer == 6) {
			Destroy (Room2Wall);
		} else if (ScoreOfPlayer == 9) {
			Destroy (Room3Wall);
		} else if (ScoreOfPlayer == 12) {
			Destroy (Room4Wall);
		} else if (ScoreOfPlayer == 15) {
			Destroy (Room5Wall);
		}*/
	}
}
