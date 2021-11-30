using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private GameObject p;
	private GameObject a;
	private Rigidbody2D rb;
	private Animator an;
	private SpriteRenderer sr;
	private GameObject go;
	private GameStatus gs;

	//Movement Fields
	public float initX;
	public float initY;
	public Vector2 initPosition;
	public float moveSpeed;
	public float jumpForce;
	private float moveHorizontal;
	private float gravity;
	private float gravityMultiplier;
	private float lowJumpGravityMultiplier;
	private float linearDrag;
	public float rbVely;
	public float rbVelx;
	public bool isGrounded;
	public Transform isGroundedChecker;
	public float checkGroundRadius;
	public LayerMask groundLayer;
	public bool isAttacking;
	public bool isStabbing;

	//Player Attribute Fields
	private float maxHealth;
	public float minHealth;


	//Player Attack Fields
	public float initStabDamage;
	public float initSwingDamage;
	public Transform attackPoint;
	public float attackRange = 2f;
	public float stabRange = 2.7f;
	public LayerMask enemyLayer;

	// Use this for initialization
	void Start () {

		p = GameObject.FindGameObjectWithTag("Player");
		rb = p.GetComponent<Rigidbody2D>();
		a = GameObject.FindGameObjectWithTag("Animation");
		an = a.GetComponent<Animator>();
		go = GameObject.Find("GameStatus");
		gs = go.GetComponent<GameStatus>();

		initX = Input.GetAxisRaw("Horizontal");
		initY = Input.GetAxisRaw("Vertical");
		initPosition = new Vector2(initX, initY);



		moveSpeed = 1f;
		jumpForce = 30f;
		isGrounded = false;
		gravity = 1f;
		gravityMultiplier = 5f;
		linearDrag = 3f;
		isAttacking = false;
		isStabbing = false;

		
		maxHealth = 100f;
		minHealth = 0f;
		initStabDamage = 10;
		initSwingDamage = 20;

		rb.transform.position = gs.playerPos;
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontal = Input.GetAxisRaw("Horizontal"); //A, D, Left Arrow, Right Arrow

		rbVelx = rb.velocity.x;
		rbVely = rb.velocity.y;

		if (!gs.isGameOver)
		{
			checkIfDead();
			groundedChecker();
			jump();
			modifyJump();
		}
	}

	void FixedUpdate()
    {
		if(!gs.isGameOver)
		{
			movePlayer();
			attack();
			stab();
		}
	}





	//Movement Methods ------------------------------------------------------------------------
	void movePlayer()
    {
		if (moveHorizontal > 0 || moveHorizontal < 0)
        {
			rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

	void jump()
    {
		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void groundedChecker()
    {
		Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
		if (collider != null)
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}

	void modifyJump()
    {
		rb.gravityScale = gravity;
		if (!isGrounded)
		{
			if (rb.velocity.y < 0f)
			{
				rb.gravityScale = (2 * gravity) * gravityMultiplier;
			}
			else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
			{
				rb.gravityScale = gravity * gravityMultiplier; 
				
			}
		}
	}

	//Attack Methods ------------------------------------------------------------------------

	void takeDamage(float amount)
	{
		gs.health -= amount;
		if (gs.health < 0)
        {
			gs.health = 0;
			gs.isDead = true;
        }

	}

	void attack()
    {
		if (!isAttacking && Input.GetKeyDown(KeyCode.E))
        {
			isAttacking = true;
			Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
			Debug.Log(hitEnemies.Length);
			foreach (Collider2D e in hitEnemies)
			{
				e.GetComponent<EnemyAI>().takeDamage(initSwingDamage, "attack");
			}
			StartCoroutine(attackWaiter("Attack"));
		}
	}
	
	void stab()
    {
		if (!isStabbing && Input.GetKeyDown(KeyCode.Q))
		{
			isStabbing = true;
			Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
			foreach (Collider2D e in hitEnemies)
			{
				e.GetComponent<EnemyAI>().takeDamage(initStabDamage, "stab");
			}
			StartCoroutine(attackWaiter("Stab"));
		}
	}

	IEnumerator attackWaiter(string attackType)
	{
		an.Play(attackType);

		yield return new WaitForSeconds(0.5f);
		an.Play("Idle");
		isAttacking = false;
		isStabbing = false;
	}

	// Item Pick Up Methods --------------------------------------------------------------------

	public bool pickUp(GameObject obj)
	{
		Debug.Log("Enter pickup function");
		Debug.Log(obj.tag);
		switch (obj.tag)
		{
			case "HealthPotion":
				gs.increaseHealth(20);
				return true;
			case "Coin":
				gs.increaseScore(10);
				return true;
			case "Key":
				gs.increaseObjectsFound(1);
				return true;
			default:
				return false;
		}
	}


	//Death or Game Over Methods -------------------------------------------------------------
	private void checkIfDead()
    {
		if (gs.isDead)
        {
			gs.isDead = true;
			if (gs.lives <= 1)
            {
				GameOver();
            }
			else
            {
				gs.isDead = false;
				StartCoroutine(deathWaiter());
			}
        }
	}
	IEnumerator deathWaiter()
	{
		an.Play("Die");
		gs.lives = gs.lives - 1;
		
		yield return new WaitForSeconds(1f);
		resetPlayerPos();
	}

	void GameOver()
    {
		//Game Over
		gs.lives = 0;
		gs.isGameOver = true;
		Debug.Log("GAME OVER");
	}

	void resetPlayerPos()
	{
		an.Play("Idle");
		gs.health = 100f;
		gs.isDead = false;

		rb.transform.position = initPosition;

	}

	private void OnDrawGizmos()
    {
		if (attackPoint == null)
        {
			return;
        }
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
