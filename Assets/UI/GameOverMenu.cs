using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	[SerializeField] GameObject menu;
	[SerializeField] Animator canvasAnim;
	void Start()
	{
		GameManager.playerTransform.GetComponent<PlayerHealth>().OnPlayerDeath += OpenGameOverMenuOnEvent;
	}

	void OpenGameOverMenuOnEvent(object sender, EventArgs args)
	{
		OpenGameOverMenu();
	}

	void OpenGameOverMenu()
	{
		canvasAnim.SetBool("GameOver", true);
		menu.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
