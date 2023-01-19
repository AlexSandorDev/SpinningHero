using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	[SerializeField] int damage = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var playerHpScript = collision.gameObject.GetComponent<PlayerHealth>();
		if (playerHpScript != null)
		{
			playerHpScript.ModifyHealth(-damage);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var playerHpScript = collision.gameObject.GetComponent<PlayerHealth>();
		if (playerHpScript != null)
		{
			playerHpScript.ModifyHealth(-damage);
		}
	}
}
