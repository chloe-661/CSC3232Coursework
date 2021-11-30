using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

	//Singleton Pattern
	static GameStatus current;
	public float health;
	public float lives;
	public float score;
	public bool isDead;
	public bool isGameOver;
	public bool hasWon;
	public float playerX;
	public float playerY;
	public Vector2 playerPos;
	public float highScore;
	public float keysFound;
	public float totalKeys;

	// Use this for initialization
	void Start () {

		if (current != null)
		{
			Debug.Log("This is not the original");
			//This is a copy of gameStatus, so delete it
			Destroy(this.gameObject);
			return;
		}

		//Otherwise this is the only copy of player and continue as normal
		current = this;
		GameObject.DontDestroyOnLoad(this.gameObject);

		restart();
	}

	public void increaseHealth(int amount)
    {
		health += amount;
    }

	public void decreaseHealth(int amount)
    {
		if (health <= (100 - amount))
		{
			health -= amount;
		}
    }

	public void increaseScore(int amount)
	{
		score += amount;
	}

	public void increaseObjectsFound(int amount)
    {
		if (keysFound < totalKeys)
		{
			keysFound += amount;
		}

		if (keysFound == totalKeys)
        {
			//Player wins
			hasWon = true;
			isGameOver = true;
        }
	}

	public void restart()
    {
		hasWon = false;
		health = 100f;
		highScore = 0f;
		score = 0f;
		isDead = false;
		isGameOver = false;
		lives = 3f;
		keysFound = 0;
		totalKeys = 4;
	}
}
