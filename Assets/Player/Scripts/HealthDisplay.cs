using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
	[SerializeField] private Animator[] healthAnimators;

	private int maxHealth;
	public void SetMaxHealth(int _health)
	{
		maxHealth = Mathf.Clamp(_health, 1, healthAnimators.Length);
		for (int i = maxHealth; i < healthAnimators.Length; i++)
		{
			healthAnimators[i].gameObject.SetActive(false);
		}
	}

	public void SetHealth(int _health, int _previousHealth)
	{
		_health = Mathf.Clamp(_health, 0, maxHealth);

		if (_previousHealth < _health)
		{
			for (int i = _previousHealth; i < _health; i++)
			{
				healthAnimators[_health - 1].SetTrigger("Heal");
			}
			return;
		}

		for (int i = _health; i < _previousHealth; i++)
		{
			healthAnimators[_health].SetTrigger("Break");
		}
	}
}
