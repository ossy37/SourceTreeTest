using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateHP : MonoBehaviour {
	
	public float HP;
	private float startingHP;
	public float damage;

	void Start() {
		startingHP = HP;
	}

	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Red Bullet")	{
			HP = HP - damage;
		} 

		if (other.tag == "Regenerate") {
			HP = startingHP;
			Destroy (other.gameObject);
		}
	}
}
