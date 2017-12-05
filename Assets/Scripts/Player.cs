using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public GameObject swetPrefab;
	public Transform sweatSpawnPoint;

	public float moveSpeed = 1f;
	public float jumpPower = 15f;
	public float bmi = 30f;

	Rigidbody2D rb;
	Main main;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		main = GameObject.FindGameObjectWithTag ("Main").GetComponent<Main> ();

		main.SetBmi (Mathf.Clamp (bmi, 0, 100f));
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q)) {
			Jump (-1f);
		} else if (Input.GetKeyDown (KeyCode.W)) {
			Jump (1f);
		}

		main.SetScore (transform.position.y);

		main.SetBmi (Mathf.Clamp (bmi, 0, 100f));
		if (bmi <= 0) {
			Dead ();
		}
	}

	void Jump (float moveDirection)
	{
		transform.localScale = new Vector3 (moveDirection, 1, 1);
		rb.velocity = new Vector2 (moveDirection * moveSpeed, jumpPower);

		bmi -= 0.1f;
		jumpPower = ((50f - bmi) / 2.5f) + 5f;

		Instantiate (swetPrefab, sweatSpawnPoint.position, Quaternion.identity);
	}

	void Dead ()
	{
		rb.velocity = Vector2.zero;
		Destroy (this);
		main.EndGame ();
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.tag == "Food") {
			bmi += 10f;
			Destroy (c.gameObject);
		}
		if (c.tag == "Trap") {
			Dead ();
		}
	}
}
