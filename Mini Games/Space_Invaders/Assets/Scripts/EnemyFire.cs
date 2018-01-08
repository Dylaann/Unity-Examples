using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

	private GameController gameController;
	public GameObject shot;
	private bool fired = false;
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		InvokeRepeating ("Fire", 1.0f, 2.0f);
	}

	void Fire () {
		while (!fired) {
			int changeFunction = UnityEngine.Random.Range (1, 11);
			int randomObjectIndex = UnityEngine.Random.Range (0, 11 - 1);
			if (transform.GetChild (randomObjectIndex).tag == "Enemy") {
				Instantiate (shot, new Vector2 (transform.GetChild (randomObjectIndex).GetComponent<Rigidbody2D> ().position.x, transform.GetChild (randomObjectIndex).GetComponent<Rigidbody2D> ().position.y - 1),
					new Quaternion (0, 0, 0, 0)); 
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();
				fired = true;
			}

		}
		fired = false;
	}
}
