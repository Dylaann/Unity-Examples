using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Dylan Murphy
/// Date: 25/09/2017
/// Moves sprites in a random direction
/// </summary>/// 


public class Pickup_Movement : MonoBehaviour {

	private Rigidbody2D rb2d; 

	private const float SPEED = 100f;
	private Vector3 direction;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
		rb2d.AddForce(direction * SPEED);
		transform.localScale = transform.localScale * Random.Range(0.6f, 1.6f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			if (transform.localScale.x > other.gameObject.transform.localScale.x) 
			{
				
				transform.localScale = transform.localScale * (float)1.05;
				other.gameObject.SetActive(false);
			}

		}
	}
}
