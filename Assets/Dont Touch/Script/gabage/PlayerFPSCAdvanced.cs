using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//[RequireComponent(typeof(CharacterController))]
public class PlayerFPSCAdvanced : MonoBehaviour {

	public float speed = 1.0f;
	private float straffe;	//X axis
	private float translation;	//Z axis	
	private float verticalVelocity;	//Y axis
	private float jumpSpeed;
	public GameObject bullet;
	public GameObject gun;
	public float bulletSpeed = 20f;

	private Slider playerHealth;
	public float HP;
	private float startingHP;
	public float damage;

	void Start()	{
	//	player = GetComponent<CharacterController> ();
		verticalVelocity = jumpSpeed;
		Cursor.lockState = CursorLockMode.Locked;
		playerHealth = GameObject.Find ("HP").GetComponent<Slider> ();
		playerHealth.maxValue = HP;
		startingHP = HP;
	}

	void Update()	{
		translation = Input.GetAxis ("Vertical") * speed;
		straffe = Input.GetAxis ("Horizontal") * speed;

		translation = translation * Time.deltaTime;
		straffe = straffe * Time.deltaTime;

		transform.Translate (straffe, 0, translation);



		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;



		playerHealth.value = HP;
	}

	void Fire()	{

		Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 0));
		bullet.GetComponent<Rigidbody> ().velocity = gun.transform.forward * bulletSpeed;

		Destroy (bullet, 2.0f);
	}

	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Red Bullet")	{
			HP = HP - damage;
		} 

		if (other.tag == "Regenerate") {
			HP = startingHP;
			Destroy (other.gameObject);
		}
	}
}
