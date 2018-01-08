using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		if (gameObject.GetComponent<Rigidbody2D> ().position.y > -3) {
			GetComponent<Rigidbody2D> ().velocity = transform.up * -speed;
		} else {
			GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		}
	}
}
