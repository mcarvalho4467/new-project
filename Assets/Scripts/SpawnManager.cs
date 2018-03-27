using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject obj;
	Vector2 spawnPoint;
	public float spawnRate;
	public float nextSpawn;

	void Update () 
	{
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			spawnPoint = new Vector2 (transform.position.x, transform.position.y);
			Instantiate (obj, spawnPoint, Quaternion.identity);
		}
	}
}
