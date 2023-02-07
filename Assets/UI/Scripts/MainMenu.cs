using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	static Transform parent;
	[SerializeField] private float timeAfterStart = 1;
	[SerializeField] private float timeAfterPress = .2f;
	[SerializeField] Transition transition;

	private void Awake()
	{
		parent = transform;

		StartCoroutine(StartGameCoroutine());
	}

	private IEnumerator StartGameCoroutine()
	{
		yield return new WaitForSeconds(timeAfterStart);

		parent.GetChild(0).gameObject.SetActive(true);
	}

	public void Play()
	{
		LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	async void LoadScene(int sceneIndex)
	{
		await transition.In();

		SceneManager.LoadScene(sceneIndex);
	}
}
