using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//chargergames
public class ObjectGenerator : MonoBehaviour {

	public GameObject spawn;
	public float GeneratingTime = 1f;

	void Start()	{
		StartCoroutine (spawnObject ());
	}
		
	IEnumerator spawnObject()	{
		while (true) {
			yield return new WaitForSeconds (GeneratingTime);
			Instantiate (spawn, transform.position, Quaternion.Euler (0, 0, 0));
		}
	}
}
