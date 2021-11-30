using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private GameObject a;
	private Animator an;
	private GameObject go;
	private GameStatus gs;
	private GameObject p;
	private Rigidbody2D rb;

	private Vector3 startingPosition;
	private Vector3 roamPosition;

	public float health;
	public bool isDead;
	public float damageOutput;

	public float moveSpeed;
	private float moveHorizontal;
	private float moveVertical;
	public bool isAttacking;
	public bool isIdle;
	public bool isPatrolling;
	public bool isChasing;
	bool isFacingRight;
	private int moveCounter;
	public bool spottedPlayer;
	private bool reachedPosition;

	private Vector2 playerPos;

	// Use this for initialization
	void Start () {
		a = GameObject.FindGameObjectWithTag("EnemyAnimation");
		an = a.GetComponent<Animator>();

		go = GameObject.Find("GameStatus");
		gs = go.GetComponent<GameStatus>();

		p = GameObject.FindGameObjectWithTag("Player");
		rb = p.GetComponent<Rigidbody2D>();

		health = 100f;
		moveSpeed = 0.1f;
		isDead = false;
		isAttacking = false;
		isIdle = true;
		isPatrolling = false;
		isChasing = false;
		isFacingRight = true;
		moveCounter = 0;
		startingPosition = transform.position;
		playerPos = new Vector2(p.transform.position.x, p.transform.position.y);
		spottedPlayer = false;
		roamPosition = getRoamingPosition();
		//Debug.Log(roamPosition);
		reachedPosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontal = Input.GetAxisRaw("Horizontal"); //A, D, Left Arrow, Right Arrow
		moveVertical = Input.GetAxisRaw("Vertical");

		checkIfDead();
		move();
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Water"))
		{
			Debug.Log("Testing water - enemy");
			KillEnemy();
		}

		if (other.CompareTag("EnemyWalls"))
        {
			Debug.Log("hit Enemy Walls");
        }
	}

	private void OnTriggerStay2D(Collider2D other)
    {

    }

	public void setPlayerSpotted()
    {

    }

	private void OnTriggerExit2D(Collider2D other)
	{
	}

	private float getRandomDirection()
    {
		float rnd = UnityEngine.Random.Range(0,1);
		if (rnd == 0)
        {
			return -1;
			//Going left
        }
        else
        {
			return rnd;
			//Going right
        }
		
    }

	private Vector3 getRoamingPosition()
    {
		
		float x = startingPosition.x + (UnityEngine.Random.Range(0f, 25f) * getRandomDirection());
		float y = startingPosition.y;

		return new Vector3(x, y);

	}

	public void move()
    {

		//NOW MOVED TO A DIFFERENT FUNCTION
		//BELOW IS THE BEGINNING TO A 'PATROLLING' ALGORITHM

		//if (isIdle == true)
		//{
		//	an.Play("Rogue_idle_01");
		//}
		//if (spottedPlayer == true)
		// {
		//	isChasing = true;
		// }
		//else
		// {
		//	isChasing = false;
		// }

		//Debug.Log("running move()");
		//Debug.Log(transform.position.x + "," + transform.position.y);
		


		//float reachedPositionDistance = 1f;
		//reachedPosition = (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) ? true : false;
		//Debug.Log(Vector3.Distance(transform.position, roamPosition));
		//Debug.Log(reachedPosition);
		//if (reachedPosition == false)
        //{
		//	an.Play("Rogue_walk_01");
		//	Debug.Log("Patrolling");
		//	transform.position = Vector2.MoveTowards(startingPosition, roamPosition, moveSpeed/2);
		//}
		//else
        //{
		//	Debug.Log("Getting new roamPosition");
		//	roamPosition = getRoamingPosition();
        //}
		//
		//if (isChasing == true)
        //{
		//	an.Play("Rogue_run_01");
		//	//Debug.Log("Is Now Chasing");
		//	playerPos = new Vector2(p.transform.position.x, p.transform.position.y - 2f);
		//	//Debug.Log("PlayerPos = " + playerPos);
		//	//Debug.Log("EnemyPos = " + transform.position.x + "," + transform.position.y);
		//	transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed);
		//}



	}

	//Attack Methods ------------------------------------------------------------------------

	public void takeDamage(float amount, string type)
	{
        switch (type)
        {
			case "attack":
				health -= amount;
				break;

			case "Stab":
				//Some kind of collision resolution/physics stuff
				break;
        }
	}


	//Death Methods -------------------------------------------------------------
	private void checkIfDead()
	{
		Debug.Log("Testing death");
		if (isDead || health <= 0)
		{
			Debug.Log("Testing death2");
			isDead = true;
			
			StartCoroutine(deathWaiter());
		}
	}
	IEnumerator deathWaiter()
	{
		an.Play("Explosion");
		gs.score += 100;
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	}

	private void KillEnemy()
    {
		health = 0;
		isDead = true;
    }
}
