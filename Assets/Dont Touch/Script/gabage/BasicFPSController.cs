using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFPSController : MonoBehaviour {

	public float speed = 2f;
//	public float sensitivity = 3f;
	public float JumpSpeed = 5f;

	public float playerheight = 2f;

	private float translation;
	private float straffe;
//	private float rotX;
//	private float rotY;
	private float verticalVelocity;

	public int jumpTimes = 1;
	private int _jumpTimes;

//	public GameObject eyes;

	private CharacterController player;

	// Use this for initialization
	void Start () {
		//this.   points to the whatever this script is on which is pointless in this moment
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		translation = Input.GetAxis("Vertical") * speed;
		straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime; //keeps the player moving at same speed
		straffe *= Time.deltaTime;

//		rotX = Input.GetAxis ("Mouse X") * sensitivity;
//		rotY = Input.GetAxis ("Mouse Y") * sensitivity;
//		rotX = Mathf.Clamp (rotX, -90f, 90f);

		Vector3 movement = new Vector3 (straffe, verticalVelocity, translation);

		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);

//		transform.Rotate (0, rotX, 0);
//		eyes.transform.Rotate (-rotY, 0, 0);
		//eyes.transform.localRotation = Quaternion.Euler(-rotY,0, 0);

		if (player.isGrounded == true) {
			_jumpTimes = 0;
		}

		if (_jumpTimes < jumpTimes) {
			if (Input.GetKeyDown ("space")) {
				verticalVelocity += JumpSpeed;
				_jumpTimes++;
			}
		}

		if (player.isGrounded == false) {
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		} else {
			verticalVelocity = 0f;
		}

		if (Input.GetKeyDown ("c")) {
			if (player.isGrounded == true) {
				player.height = playerheight / 2;
			} else {
				player.height = playerheight;
			}
		}
	}
		
}
