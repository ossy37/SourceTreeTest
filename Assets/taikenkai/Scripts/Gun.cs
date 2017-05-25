using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject ammo;
	public GameObject shotPoint;

	public int bulletSpeed = 50;

	void Start () {}

	void Update () {}

	public void Shot() {
		GameObject bullet = Instantiate (ammo, shotPoint.transform.position, shotPoint.transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody> ().AddForce (shotPoint.transform.forward * bulletSpeed * 100);
	}
}
