using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformInDirection : MonoBehaviour {

	Rigidbody playerRigid;
	public float speed;
	// Use this for initialization
	void Start () {
		playerRigid = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		playerRigid.velocity = new Vector3 (0, 0, -1) * speed;
	}
}
