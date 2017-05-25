using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook1 : MonoBehaviour {

	public float sensitivity = 50f;

	void Update()	{
		var rot = new Vector3(0f, 0f, 0f);
		// rotates Camera Left
		if (Input.GetAxis("Mouse X") < 0)
		{
			rot.x -= 1;
		}
		// rotates Camera Left
		if (Input.GetAxis("Mouse X") > 0)
		{
			rot.x += 1;
		}

		// rotates Camera Up
		if (Input.GetAxis("Mouse Y") < 0)
		{
			rot.y -= 1;
		}
		// rotates Camera Down
		if (Input.GetAxis("Mouse Y") > 0)
		{
			rot.y += 1;
		}

		transform.Rotate(rot, sensitivity * Time.deltaTime);
	}
}