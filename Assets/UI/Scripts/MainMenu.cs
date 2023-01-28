using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	static Transform parent;
	[SerializeField] private float timeAfterStart = 1;
	[SerializeField] private float timeAfterPress = .2f;
	[SerializeField] Animator transitionAnimator;

	private void Awake()
	{
		parent = transform;

		try
		{
			transitionAnimator.SetTrigger("In");
		}
		catch (Exception e) when (e is NullReferenceException || e is UnassignedReferenceException)
		{
			Debug.LogWarning("No transition animator selected");
			transitionAnimator = null;
		}

		StartCoroutine(StartGameCoroutine());
	}


	private IEnumerator StartGameCoroutine()
	{
		yield return new WaitForSeconds(timeAfterStart);

		parent.GetChild(0).gameObject.SetActive(true);
	}

	public void Play()
	{
		transitionAnimator?.SetTrigger("Out");
		StartCoroutine(PlayCoroutine());
	}

	private IEnumerator PlayCoroutine()
	{
		yield return new WaitForSeconds(timeAfterPress);

		var operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

		if (operation.isDone)
		{
			transitionAnimator?.SetTrigger("In");
		}
	}
}
