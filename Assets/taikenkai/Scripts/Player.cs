using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Target {
	public int Score;
	private Slider HP_Slider;
	private Gun _Gun;
	public GameObject HP_Slider_GO;

	// Use this for initialization
	void Start () {
		HP = HP_max;
		HP_Slider = HP_Slider_GO.GetComponent<Slider> ();
		_Gun = GameObject.Find ("Gun").GetComponent<Gun> ();
	}
	
	// Update is called once per frame
	void Update () {
		HP_update ();
		if (Input.GetMouseButtonDown (0)) {
			_Gun.Shot ();
		}
	}

	void damage(int damageNum) {
		HP -= damageNum;
		if(HP < 0) {
			HP = 0;
			// GAME OVER
			return;
		}
	}

	void HP_update() {
		// update UI
		HP_Slider.value = (float) HP / HP_max;
	}
}
