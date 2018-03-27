using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour {

	public float vX;
	public float vZ;

	private Rigidbody2D rb2d;
	private Animator anim;


	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () 
	{
		anim.SetFloat ("Speed", rb2d.velocity.x);
		rb2d.velocity = new Vector2 (vX, vZ);
		Destroy (gameObject, 15f);
	}

}
