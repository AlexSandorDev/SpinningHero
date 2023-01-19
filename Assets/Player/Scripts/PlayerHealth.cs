using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[field: SerializeField] public HealthClass health { get; private set; }
	[SerializeField] private Animator uiDamageEffect;
	private HealthDisplay healthDisplay;
	public event EventHandler OnPlayerDeath;

	SpriteRenderer sr;

	private void Start()
	{
		healthDisplay = GetComponent<HealthDisplay>();
		sr = GetComponentInChildren<SpriteRenderer>();

		health.Initialize();
		health.OnDeath += Die;
		healthDisplay.SetMaxHealth((int)health.MaxHp);
	}

	private void Die()
	{
		OnPlayerDeath?.Invoke(null, null);
		Destroy(gameObject);
	}

	public void ModifyHealth(int _amount)
	{
		var _prevHp = health.CurrentHp;
		health.ModifyHp(_amount);
		healthDisplay.SetHealth((int)health.CurrentHp,(int)_prevHp);
		if (_amount < 0){
			uiDamageEffect.SetTrigger("Damage");
			StartCoroutine(ChangeHealthAnimation(health.invincibilityDurration,Color.red));
		}
		else if (_amount > 0)
			StartCoroutine(ChangeHealthAnimation(health.invincibilityDurration,Color.green));

	}

	private IEnumerator ChangeHealthAnimation(float _time,Color color)
	{
		sr.color = color;
		yield return new WaitForSeconds(_time);
		sr.color = Color.white;
	}
}
