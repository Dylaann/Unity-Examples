using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

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

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.playerLives -= 1;
			gameController.UpdateLives ();
			if (gameController.playerLives == 0) 
			{
				gameController.GameOver ();
			}
		}

		if (other.tag != "Player") {
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else if (other.tag == "Player" && gameController.playerLives > 0) 
		{
			Instantiate (other.gameObject, new Vector3 (0, 0, 0), new Quaternion(0, 0, 0, 0));
			Destroy (other.gameObject);
		} 
		else
		{
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}


	}
		
}
