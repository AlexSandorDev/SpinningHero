using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ScoreHandler : MonoBehaviour
{
	public event EventHandler OnScoreChange;

	private ScoreDisplay scoreDisplay;
	private int score;
	private int highScore;

	private void Start()
	{
		GameManager.onEnemyDeath += UpdateScoreOnEvent;
		scoreDisplay = GetComponent<ScoreDisplay>();

		highScore = PlayerPrefs.GetInt("HighScore", 0);
		score = 0;

		scoreDisplay.UpdateScoreDisplay(score);
		scoreDisplay.UpdateHighScoreDisplay(highScore);
	}

	private void UpdateScoreOnEvent(object sender, OnEnemyDeathArgs args)
	{
		UpdateScore(args.scoreIncrease);
	}

	public void UpdateScore(int amount)
	{
		score += amount;
		scoreDisplay.UpdateScoreDisplay(score);
		if (score > highScore)
		{
			highScore = score;
			scoreDisplay.UpdateHighScoreDisplay(highScore);
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}
}
