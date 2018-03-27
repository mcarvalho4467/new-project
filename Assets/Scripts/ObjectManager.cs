using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	public float vX;
	public float vZ;

	private Rigidbody2D rb2d;


	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void Update () 
	{
		rb2d.velocity = new Vector2 (vX, vZ);
		Destroy (gameObject, 15f);
	}
}
