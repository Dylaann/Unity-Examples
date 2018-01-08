using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	private Rigidbody rb;
	public Text countText;
	public Text winText;
	public float speed;

	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(move * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 16) 
		{
			winText.text = "You Win!!";
		}
	}
}