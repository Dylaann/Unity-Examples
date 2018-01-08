using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	private GameController gameController;
	public int scoreValue;

	void Start ()
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
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		if (other.tag == "Bullet" && tag == "Defender") {
			transform.localScale = transform.localScale * (float)0.9;
			Destroy (other.gameObject);
			gameController.PlayWallSound ();
			if (gameObject.transform.localScale.x < 0.22) {
				Destroy (gameObject);
			}
		} else if (other.tag == "Bullet" && tag == "Enemy") {	
			gameController.PlayEnemySound ();
			gameController.AddScore (scoreValue);
			gameController.ReduceEnemies ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else if (other.tag == "Player" && tag == "Enemy") {
			gameController.AddScore (-scoreValue);
			gameController.playerLives -= 1;
			gameController.UpdateLives ();
			gameObject.GetComponent<Rigidbody2D> ().MovePosition (new Vector3 (gameObject.GetComponent<Rigidbody2D> ().position.x, 4, 0));
		} else if (other.tag == "Defender" && tag == "Enemy" || other.tag == "Enemy" && tag == "Defender" ) {
			return;
		} else if (other.tag == "EnemyBullet" && tag == "Player") {
			gameController.AddScore (-scoreValue);
			gameController.playerLives -= 1;
			gameController.UpdateLives ();
			Destroy (other.gameObject);
			} else if (other.tag == "Bullet" && tag == "Mystery") {
				gameController.AddScore (scoreValue * 10);
				Destroy (other.gameObject);
				Destroy (gameObject);
		} else if (other.tag == "EnemyBullet" && tag == "Defender") {
			transform.localScale = transform.localScale * (float)0.9;
			Destroy (other.gameObject);
			gameController.PlayWallSound ();
			if (gameObject.transform.localScale.x < 0.22) {
				Destroy (gameObject);
			}
		}
	}
		
}
