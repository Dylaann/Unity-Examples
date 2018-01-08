using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

	public int speed;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
	}
}
