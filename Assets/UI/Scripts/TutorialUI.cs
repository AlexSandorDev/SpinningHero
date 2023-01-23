using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
	[SerializeField] List<GameObject> objectsToActivate;
	[SerializeField] List<Behaviour> componentsToActivate;
	[SerializeField] List<GameObject> objectsToDeactivate;

	private void Start()
	{
		objectsToActivate.ForEach(x => x.SetActive(false));
		componentsToActivate.ForEach(x => x.enabled = false);
		objectsToDeactivate.ForEach(x => x.SetActive(true));
	}

	void Update()
	{
		if (Input.anyKeyDown || Input.touchCount > 0) StartGame();
	}

	void StartGame()
	{
		objectsToActivate.ForEach(x => x.SetActive(true));
		componentsToActivate.ForEach(x => x.enabled = true);
		objectsToDeactivate.ForEach(x => x.SetActive(false));
	}
}
