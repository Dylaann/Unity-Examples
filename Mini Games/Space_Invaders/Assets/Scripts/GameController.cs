using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText livesText;
	public GUIText HighScoreText;

	private bool gameOver;
	private bool restart;
	public int playerLives;

	private int score;
	private int enemies = 12;

	AudioSource wall;
	AudioSource enemy;

	public GameObject mystery;

	void Start ()
	{

		AudioSource[] sources = GetComponents<AudioSource>();
		wall = sources[0];
		enemy = sources [1];

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		HighScoreText.text = "";

		score = 0;
		UpdateScore ();
		UpdateLives ();

		InvokeRepeating ("MysteryShip", 3.0f, 6.0f);
	}

	public void AddScore (int newScoreValue)
	{
		if (!gameOver) {
			score += newScoreValue;
			UpdateScore ();
		}
	}

	void UpdateScore ()
	{
			scoreText.text = "Score: " + score;
	}

	public void UpdateLives ()
	{
		livesText.text = "Lives: " + playerLives;
		if (playerLives == 0) {
			GameOver ();
		}
	}

	public void GameOver ()
	{
		HighScoreText.text = "Your Score: " + score;
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void ReduceEnemies()
	{
		enemies -= 1;
		if (enemies == 0) {
			GameOver ();
		}
	}

	public void PlayWallSound()
	{
		wall.Play();
	}

	public void PlayEnemySound()
	{
		enemy.Play();
	}

	void Update ()
	{

		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void MysteryShip()
	{
		if (!gameOver) {
			Instantiate (mystery);
		}
	}
}