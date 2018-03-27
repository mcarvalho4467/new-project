using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public List<GameObject> spawnPositions;
	public List<GameObject> spawnObjects;  

	public float spawnRate;
	public float nextSpawn;

	void Start()
	{
		SpawnObjects();
	}

	void Update ()
	{
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnObjects ();
		}
	}

	void SpawnObjects()
	{
		foreach(GameObject spawnPosition in spawnPositions)
		{
			int selection = Random.Range(0, spawnObjects.Count);
			Instantiate(spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation);
		}
	}
}
