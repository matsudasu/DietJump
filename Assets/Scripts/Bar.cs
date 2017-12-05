using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
	public Transform target;

	public float speed = 1f;
	public float maxDistance = 10f;

	bool isReady;

	void Update ()
	{
		if (!isReady) {
			if (Input.anyKeyDown) {
				isReady = true;
			}
			return;
		}

		var pos = transform.position;

		pos.x = target.position.x;

		if (target.position.y > transform.position.y + maxDistance) {
			pos.y = target.position.y - maxDistance;
		}
		pos.y += speed * Time.deltaTime;

		transform.position = pos;
	}
}
