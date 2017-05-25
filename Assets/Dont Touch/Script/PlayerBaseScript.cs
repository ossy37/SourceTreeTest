using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerBaseScript : MonoBehaviour {

	public float speed = 10.0f;
	public float JumpSpeed = 5f;
	public float gravity;
	public float NumberToClear;
//	private float timeCounter;

	public AudioClip obtainedAudio;
	public AudioClip JumpAudio;
	private new AudioSource audio;

	public float playerFeetPos;
	public float raycastDistance = 0.5f;
	private bool isGrounded;
	public LayerMask layer;

	public int JumpCounter;
	private int _JumpCounter;

	public Text Score;
	public Text Result;

	public string JumpButton;

	private int score;

	private new Rigidbody rigidbody;

	public Text HPtext;
	public float startingHP;
	public float startingStamina;
	private Slider HPslider;
	private Slider Stamslider;
	private float hp;
	private float stamina;

	private float extra;

	private camMouseLook mouseInput;

	public GUITexture overlay;
	public float fadeTime;

	public string nextScene;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		_JumpCounter = 0;
//		timeCounter = 0;
		Cursor.lockState = CursorLockMode.Locked; //disappears mousepointer and locks into screen
		score = 0;
		Result.text = "";
		SetScoreText ();
		rigidbody = GetComponent<Rigidbody> ();

		HPslider = GameObject.Find("HP").GetComponent<Slider> ();
		Stamslider = GameObject.Find ("Stamina").GetComponent<Slider> ();
		HPtext.text = "HP : " + startingHP.ToString ("0");
		Result.text = "";
		HPslider.maxValue = startingHP;
		hp = startingHP;
		Stamslider.maxValue = startingStamina;
		stamina = startingStamina;
		mouseInput = GameObject.Find ("Main Camera").GetComponent<camMouseLook> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime; //keeps the player moving at same speed
		straffe *= Time.deltaTime;

		transform.Translate(straffe, 0, translation);

		if(Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;//press esc to unlock the mousepointer

//		hp -= (5 + extra) * Time.deltaTime;

		if (Input.GetKey (KeyCode.LeftShift)) {
			if (stamina >= 0) {	
				speed = 20f;
				stamina -= 5 * Time.deltaTime;
			} else if (stamina <= 0)
				speed = 10f;
		} else	{
			speed = 10f;
			if (stamina < startingStamina)
				stamina += 3 * Time.deltaTime;
			else if (stamina >= startingStamina)
				stamina = startingStamina;
		}
			
		HPtext.text = "HP : " + hp.ToString ("0");
		if (hp <= 0) {
			Time.timeScale = 0;
			mouseInput.enabled = false;
			Result.text = "YOU LOSE";
			HPtext.text = "HP : 0";
			Cursor.lockState = CursorLockMode.None;
		}
		HPslider.value = hp;
		Stamslider.value = stamina;

		/*Debug.DrawRay (transform.position - new Vector3 (0, playerFeetPos, 0), Vector3.down, Color.green);
		if (Physics.Raycast (transform.position - new Vector3 (0, playerFeetPos, 0), Vector3.down, raycastDistance, layer)) {
			isGrounded = true;
			_JumpCounter = 0;
		} else {
			isGrounded = false;
		}*/
			
		if (Input.GetKeyDown (JumpButton) && _JumpCounter < JumpCounter) {
			Jump ();
		}
	}
		
	void Jump ()	{
		rigidbody.velocity = new Vector3 (0, -gravity * Time.deltaTime, 0);
		if (isGrounded == true) {
			audio.PlayOneShot (JumpAudio);
			rigidbody.AddForce (new Vector3 (0, JumpSpeed, 0));
			_JumpCounter++;
		} else if (isGrounded == false && _JumpCounter < JumpCounter) {
			rigidbody.AddForce (new Vector3 (0, JumpSpeed, 0));
			_JumpCounter++;
		}
	}

	void Awake ()	{
		overlay.enabled = true;
		//no matter what the screen size is it adjusts
		overlay.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		//fade to clear	
		StartCoroutine (FadeToClear ());
	}
	void OnTriggerEnter(Collider other)	{
		if (other.tag == "Collectable") {
			Destroy (other.gameObject);
			audio.PlayOneShot (obtainedAudio);
			score++;
			SetScoreText ();
		}

		if (other.tag == "Transfer") {
			StartCoroutine (FadeToBlack ());
		}


		if (other.tag == "Health Item") {
			HealthRegenerate ();
			other.gameObject.SetActive (false);
		}
	}

	void SetScoreText()	{
		Score.text = "Score : " + score.ToString ();
		if (score >= NumberToClear) {
			Time.timeScale = 0;
			mouseInput.enabled = false;
			Result.text = "YOU WIN!!";
			Cursor.lockState = CursorLockMode.None;
		}
	}

	void OnTriggerStay (Collider other)	{
		if(other.tag == "Dead Zone") {
			extra = 5f;
		} 
	}

	void OnTriggerExit(Collider other)	{
		if(other.tag == "Dead Zone") {
			extra = 0;
		}
	}

	void HealthRegenerate ()	{
		if (hp <= 80) {
			hp += 20;
		} else {
			hp = startingHP;
		}
	}

	 private IEnumerator FadeToClear ()	{
		overlay.gameObject.SetActive (true);
		overlay.color = Color.black;
		float rate = 1f / fadeTime;
		float progress = 0f;

		while (progress < 1f) {
			overlay.color = Color.Lerp (Color.black, Color.clear, progress);

			progress += rate * Time.deltaTime;

			yield return null;
		}
		overlay.color = Color.clear;
		overlay.gameObject.SetActive (false);
	}

	public IEnumerator FadeToBlack()	{
		overlay.gameObject.SetActive (true);
		overlay.color = Color.black;
		float rate = 1f / fadeTime;
		float progress = 0f;

		while (progress < 1f) {
			overlay.color = Color.Lerp (Color.clear, Color.black, progress);

			progress += rate * Time.deltaTime;

			yield return null;
		}
		overlay.color = Color.black;
		SceneManager.LoadScene (nextScene);
	}

}
