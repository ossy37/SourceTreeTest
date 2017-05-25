using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;//point back to character(the parent of the object this script is set to)

	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing); //Lerp = when looking at one point from another it makes it smooth
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;//adding up all the movements and applying it to the character
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f); //stops the camera from going 360 when looking over your head
	
		//(looking direction, looking up and down equals rotating around the x axis(right direction in Vector3)
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		//we want the whole character to look up = the base is the character
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);

	}
}
