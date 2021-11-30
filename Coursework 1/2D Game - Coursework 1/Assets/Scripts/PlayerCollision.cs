using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private GameObject p;
	private PlayerController pc;
	private GameObject go;
	public GameStatus gs;


	void Start(){
		p = GameObject.FindGameObjectWithTag("Player");
		pc = p.GetComponent<PlayerController>();
		go = GameObject.Find("GameStatus");
		gs = go.GetComponent<GameStatus>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		ProcessCollision(other.gameObject);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		ProcessCollision(other.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		ProcessCollision(other.gameObject);
	}

	void ProcessCollision(GameObject other)
	{

		if (other.CompareTag("Water"))
        {
			KillPlayer();
        }
	}

	void KillPlayer ()
    {
		gs.isDead = true;
		gs.health = 0;
    }
}
