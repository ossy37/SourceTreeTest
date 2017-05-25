using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRandom : MonoBehaviour {

	float x;
	float y;
	float z;
	public float frequency = 3f;
	float timer;
	Vector3 pos;

	void Start() {
		timer = 0f;
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= frequency) {
			randomPosition ();
			timer = 0f;
		}
	}

	void randomPosition()	{
		x = Random.Range (-25, 25);
		y = Random.Range (5, 15);
		z = Random.Range (-25, 25);
		pos = new Vector3 (x, y, z);
		transform.position = pos;
	}
}
