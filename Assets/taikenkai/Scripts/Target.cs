using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public int HP;
	public int HP_max;

	void Start () {
		HP = HP_max;
	}

	void Update () {}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Bullet") {
			Ammo _ammo = collider.GetComponent<Ammo> ();
			damage (_ammo.ammoPower);
			Destroy (collider);
		}
	}

	void damage(int damageNum) {
		HP -= damageNum;
		if(HP <= 0) {
			Destroy (gameObject);
		}
	}
}
