using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletDestroy : MonoBehaviour {

	public string tagName;

	void OnTriggerEnter(Collider col) {
		if (col.tag == tagName) {
			Destroy (this.gameObject);
		}
	}
}
