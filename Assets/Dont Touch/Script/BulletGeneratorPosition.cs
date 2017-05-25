using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneratorPosition : MonoBehaviour {

	private float x;
	private float y;
	private float z;

	public float frequency = 3f;
	float timer;
	Vector3 pos;

	void Start() {
		timer = 0f;
		y = transform.position.y;
		z = transform.position.z;
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= frequency) {
			randomPosition ();
			timer = 0f;
		}
	}

	void randomPosition()	{
		x = Random.Range (-15, 15);
		pos = new Vector3 (x, y, z);
		transform.position = pos;
	}
}