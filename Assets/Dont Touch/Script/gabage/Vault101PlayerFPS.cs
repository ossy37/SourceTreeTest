using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Vault101PlayerFPS: MonoBehaviour {

	public float startingSpeed;
	private float speed;
	public float gravity;

	private new Rigidbody rigidbody;

	public Text HPtext;
	public float startingHP;
	public float startingStamina;
	private Slider HPslider;
	private Slider Stamslider;
	private float hp;
	private float stamina;

	public GUITexture overlay;
	public float fadeTime;
	public string nextScene;

	public bool ObtainedKey;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked; //disappears mousepointer and locks into screen

		rigidbody = GetComponent<Rigidbody> ();

		HPslider = GameObject.Find("HP").GetComponent<Slider> ();
		Stamslider = GameObject.Find ("Stamina").GetComponent<Slider> ();
		HPtext.text = "HP : " + startingHP.ToString ("0");
		HPslider.maxValue = startingHP;
		hp = startingHP;
		Stamslider.maxValue = startingStamina;
		stamina = startingStamina;


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

		HPtext.text = "HP : " + hp.ToString ("0");

		HPslider.value = hp;
		Stamslider.value = stamina;

		if (Input.GetKey (KeyCode.LeftShift)) {
			if (stamina >= 0) {	
				speed = startingSpeed * 2;
				stamina -= 5 * Time.deltaTime;
			} else if (stamina <= 0)
				speed = startingSpeed;
		} else	{
			speed = startingSpeed;
			if (stamina < startingStamina)
				stamina += 3 * Time.deltaTime;
			else if (stamina >= startingStamina)
				stamina = startingStamina;
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
		if (other.tag == "KeyCard")	{
			ObtainedKey = true;
			Destroy (other.gameObject);
		}

		if (other.tag == "Transfer") {
			StartCoroutine (FadeToBlack ());
		}

	}

	public IEnumerator FadeToClear ()	{
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
