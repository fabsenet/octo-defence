using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	private static ScoreCounter _instance;
	private Text _scoreText;

	public float Score = 0f;
	// Use this for initialization
	void Start ()
	{
		_instance = this;
		_scoreText = GetComponent<Text>();
		SetScoreText();

	}

	private void SetScoreText()
	{
		_scoreText.text = String.Format("Score: {0:###,###}", Score);
	}

	public static void AddScore(float points)
	{
		_instance.AddScoreInternal(points);
	}

	private void AddScoreInternal(float points)
	{
		Score += points;
		SetScoreText();
	}

}
