using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionController : MonoBehaviour
{
	private GameObject a;
	private Animator an;
	private GameObject p;
	private bool isChasing;
	private bool isIdle;
	private Vector2 playerPos;
	private float moveSpeed;

	void Start()
    {
		a = GameObject.FindGameObjectWithTag("EnemyAnimation");
		an = a.GetComponent<Animator>();
		p = GameObject.FindGameObjectWithTag("Player");

		isChasing = false;
		isIdle = true;
		moveSpeed = 0.1f;
	}

	void Update()
    {
		move();
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isChasing = true;
			isIdle = false;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isChasing = false;
			isIdle = true;
		}
	}

	public void move()
    {
		if (isIdle)
        {
			an.Play("Rogue_idle_01");
		}
		if (isChasing == true)
		{
			an.Play("Rogue_run_01");
			playerPos = new Vector2(p.transform.position.x, p.transform.position.y - 2f);
			transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed);
		}
	}
}
