using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5f);	
	}

	void OnTriggerEnter(Collider col)	{
		if (col.tag == "FrontWall") {
			Destroy (gameObject);
		}
	}
}
