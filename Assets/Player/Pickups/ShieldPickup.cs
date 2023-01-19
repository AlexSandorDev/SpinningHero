using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
	[SerializeField] int score = 10;

	public event EventHandler OnPickup;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var _playerHealth = collision.gameObject.GetComponent<PlayerHealth>();


		if (_playerHealth == null) return;

		if (_playerHealth.health.CurrentHp >= _playerHealth.health.MaxHp)
		{
			GameManager.scoreHandler.UpdateScore(score);
		}
		else
		{
			_playerHealth.ModifyHealth(1);
		}


		OnPickup?.Invoke(null, null);

		Destroy(gameObject);
	}
}
