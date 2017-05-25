using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Shooter : Gun {
	public float GeneratingTime = 1f;

	void Start()	{
		StartCoroutine (spawnObject ());
	}

	IEnumerator spawnObject()	{
		while (true) {
			yield return new WaitForSeconds (GeneratingTime);
			Shot();
		}
	}
}
