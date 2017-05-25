using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetDestroy : MonoBehaviour {

	SystemManager _script;

	void Start()	{
		_script = GameObject.Find ("GameSystem").GetComponent<SystemManager> ();
	}
		
	void OnTriggerEnter(Collider col)	{
		if (col.tag == "Bullet") {
			_script.ScoreOfPlayer++;
			Destroy (gameObject);
		}
	}
}
