using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweat : MonoBehaviour 
{
	public Sprite [] sweats;

	void Start () 
	{
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (Random.Range(0, 0), 10f), ForceMode2D.Impulse);	
		GetComponent<SpriteRenderer> ().sprite = sweats [Random.Range (0, sweats.Length)];
		Destroy (gameObject, 2.0f);
	}
}
