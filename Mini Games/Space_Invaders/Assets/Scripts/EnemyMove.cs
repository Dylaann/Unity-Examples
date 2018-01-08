using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private GameController gameController;

	public float speed;
	private int direction = 1;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		InvokeRepeating ("Move", 0.0f, 1.0f);
	}
		
	void Move () {
		if (gameController.playerLives != 0) {
			if (direction == 0) {
				GetComponent<Rigidbody2D> ().velocity = transform.up * -speed;
			} else if (direction == 1) {
				GetComponent<Rigidbody2D> ().velocity = transform.right * speed * 3;
			} else if (direction == 2) {
				GetComponent<Rigidbody2D> ().velocity = transform.up * -speed;
			} else if (direction == 3) {
				GetComponent<Rigidbody2D> ().velocity = transform.right * -speed * 3;
			}

			if (direction != 3) {
				direction += 1;
			} else {
				direction = 0;
			}
		}
	}
}
