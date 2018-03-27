using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float  jumpForce;
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	public float jumpTime;
	public float jumpTimeCounter;
	public GameObject gameOverPanel;
	public GameObject winPanel;
	public bool takedamage;

	private Rigidbody2D rb2d;
	private bool canDJump;
	private Animator anim;
	private ScoreManager sm;
	[SerializeField]
	private Stats health;

	private void Awake ()
	{
		health.Initialize ();
	}

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sm = FindObjectOfType<ScoreManager> ();
		gameOverPanel.SetActive (false);
		winPanel.SetActive (false);
	}
	

	void Update () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		anim.SetFloat ("Speed", rb2d.velocity.x);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{
			if (grounded) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
			}

			if (!grounded && canDJump) 
			{
				canDJump = false;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpTime);
				jumpTimeCounter = jumpTime;
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{
			if (jumpTimeCounter > 0) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{
			jumpTimeCounter = 0;
		}

		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
			canDJump = true;
		}

		if (takedamage == true) 
		{
			health.CurrentV -= 20f;
			takedamage = false;
		}

		if (health.CurrentV <= 0) 
		{
			GameObject.FindWithTag ("Player").SetActive (false);
			gameOverPanel.SetActive (true);
		}

   }

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") 
		{
			health.CurrentV = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Star")) 
		{
			other.gameObject.SetActive (false);
			sm.scoreCount = sm.scoreCount + 20;
			sm.SetStarCount ();
		}

		if (other.gameObject.CompareTag ("Bee")) 
		{
			takedamage = true;
			other.gameObject.SetActive (false);

		}

		if (other.gameObject.CompareTag ("Heart")) 
		{
			other.gameObject.SetActive (false);
			health.CurrentV = Mathf.Min (health.CurrentV + 20f, health.MaxV);
		}

		if (other.gameObject.CompareTag ("Key")) 
		{
			other.gameObject.SetActive (false);
			sm.keyCount = sm.keyCount + 1;
			sm.SetKeyCount ();
		}

		if (sm.keyCount == 5) 
		{
			winPanel.SetActive (true);
			GameObject.FindWithTag ("Player").SetActive (false);
			GameObject.FindWithTag ("SpawnPoint").SetActive (false);
		}
	}
		
}
