using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Dylan Murphy
/// Date: 25/09/2017
/// Basic Movement for the player object
/// </summary>

public class Player_Controller : MonoBehaviour {

	public float speed;
	public Text countText;         
	public Text winText;    

	private Rigidbody2D rb2d;  
	private int count;   
	private int win = 8;
	private bool hit = false;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();

		count = 0;

		winText.text = "";
		SetCountText ();
	}
		
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) 
		{
			transform.localScale = transform.localScale * (float)0.999;
		}

		if (!hit) 
		{
			rb2d.AddForce (movement * speed);
		}

		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if (!hit) 
		{
			if (other.gameObject.CompareTag ("PickUp")) {
				//other.gameObject.SetActive(false);
				count = count + 1;
				SetCountText ();

				if (GetComponent<CircleCollider2D> ().bounds.size.x > other.gameObject.GetComponent<CircleCollider2D> ().bounds.size.x) {
					transform.localScale = transform.localScale * (float)1.05;
					other.gameObject.SetActive (false);
				} else {
					hit = true;
					winText.text = "You Lose!";
				}
			}
		}
	}

	void SetCountText()
	{
		countText.text = "Destroy 8 to win: " + count.ToString ();

		if (count >= win) 
		{
			winText.text = "You win!";
		}
	}
		
}
