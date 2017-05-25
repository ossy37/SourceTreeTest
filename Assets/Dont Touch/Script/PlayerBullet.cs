using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletEmitter;
	public float destroyFrequency;
	public string tagName;
	private GameObject bulletManager;

	public float bulletSpeed;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			bulletManager = Instantiate (bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

			Rigidbody rigidbodyManager;
			rigidbodyManager = bulletManager.GetComponent<Rigidbody> ();

			rigidbodyManager.AddForce (bulletEmitter.transform.forward * bulletSpeed * 100);
		}
	}
		
}
			