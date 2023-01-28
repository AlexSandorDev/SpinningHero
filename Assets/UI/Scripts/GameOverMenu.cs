using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	[SerializeField] GameObject menu;
	[SerializeField] Animator canvasAnim;
	void Start()
	{
		GameManager.playerTransform.GetComponent<PlayerHealth>().OnPlayerDeath += OpenGameOverMenuOnEvent;
		menu.SetActive(false);
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

	public void Home(){
		SceneManager.LoadScene(0);
	}
}
