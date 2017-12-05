using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	public GameObject start;
	public GameObject end;

	public Text scoreUi;
	public Text bmiUi;
	public Text highScoreUi;

	public int score;
	public int highScore;

	float bmiDisplay = 30f;
	float timer;

	void Start ()
	{
		start.SetActive (true);
		end.SetActive (false);

		highScore = PlayerPrefs.GetInt ("HighScore", 0);
	}
	
	void Update ()
	{
		timer += Time.deltaTime;

		if (start.activeSelf && Input.anyKeyDown) {
			StartGame ();
		}

		if (end.activeSelf && timer > 1f) {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("Main");
			}
		}
	}

	public void SetScore (float n)
	{
		if (score < n) {
			score = (int)n;
			scoreUi.text = score.ToString ("0") + "m";
		}
	}

	public void SetBmi(float bmi)
	{
		bmiDisplay = Mathf.MoveTowards (bmiDisplay, bmi, Time.deltaTime * 8f);
		bmiUi.text = "BMI " + bmiDisplay.ToString ("0.0");
	}

	public void StartGame()
	{
		start.SetActive (false);
		score = 0;
	}

	public void EndGame()
	{
		end.SetActive (true);
		timer = 0;

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		highScoreUi.text = highScore + "m";
	}
}
