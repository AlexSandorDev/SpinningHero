using System;
using System.Collections;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
	[SerializeField] private HealthClass health;
	[SerializeField] private int score;

	SpriteRenderer sr;

	private void Start()
	{
		health.Initialize();
		health.OnDeath += Die;
		sr = GetComponentInChildren<SpriteRenderer>();
	}

	public void ModifyHp(float amount)
	{
		health.ModifyHp(amount);
		sr.color = Color.red;

		//StartCoroutine(DamageAnimation(health.invincibilityDurration));
	}

	private IEnumerator DamageAnimation(float time)
	{
		yield return new WaitForSeconds(time);
		sr.color = Color.white;
	}

	private void Die()
	{
		GameManager.OnEnemyDeath(this, new GameManager.OnEnemyDeathArgs
		{
			scoreIncrease = score
		});

		Pooling.pooling.Destroy(gameObject);
	}
}
