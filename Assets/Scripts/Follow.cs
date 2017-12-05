using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	public Transform target;

	float height;
	bool isReady;

	void Update ()
	{
		if (!isReady) {
			if (Input.anyKeyDown) {
				isReady = true;
			}
			return;
		}

		var pos = target.position;

		if (height < pos.y) {
			height = pos.y;
		}
		pos.y = height;

		transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime * 2f);
	}
}
