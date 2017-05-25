using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSC : MonoBehaviour {

	public float speed;
	private float straffe;	//X axis
	private float translation;	//Z axis
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		translation = Input.GetAxis ("Vertical") * speed;
		straffe = Input.GetAxis ("Horizontal") * speed;

		translation = translation * Time.deltaTime;
		straffe = straffe * Time.deltaTime;

		transform.Translate (straffe, 0, translation);
	}
}
