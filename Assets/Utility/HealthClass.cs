using System;
using System.Collections;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

[System.Serializable]
public class HealthClass
{
	[field: SerializeField]
	public float MaxHp { get; private set; }
	public float CurrentHp { get; private set; }

	[Tooltip("In Milliseconds")]
	[field: SerializeField] public float invincibilityDurration { get; private set; }
	private bool invincibile;


	public delegate void DeathDelegate();
	public event DeathDelegate OnDeath;

	public void Initialize()
	{
		CurrentHp = MaxHp;
	}

	public void ModifyHp(float amount)
	{
		if (invincibile && amount <0) return;

		CurrentHp = Mathf.Clamp(CurrentHp + amount, 0, MaxHp);

		if (CurrentHp <= 0)
		{
			OnDeath?.Invoke();
		}

		Invincible();
	}

	async void Invincible()
	{
		invincibile = true;
		await Task.Delay((int)invincibilityDurration*1000);
		invincibile = false;
	}

}
