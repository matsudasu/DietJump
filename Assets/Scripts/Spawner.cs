using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] items;

	public float nextSpawn = 10f;
	public float baseInterval = 3f;

	void Update ()
	{
		while (transform.position.y > nextSpawn) 
		{
			var pos = transform.position;
			pos.x = Random.Range (pos.x - 5f, pos.x + 5f);
			Destroy(Instantiate (items [Random.Range(0, items.Length)], pos, Quaternion.identity), 10f);

			nextSpawn += baseInterval + Random.Range(-1, 1f);
		}
	}
}
