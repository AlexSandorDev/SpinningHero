using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
	[SerializeField] float damage = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var enemyHpScript = collision.gameObject.GetComponent<EnemyHealthHandler>();
		if(enemyHpScript!=null){
			enemyHpScript.ModifyHp(-damage);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var enemyHpScript = collision.gameObject.GetComponent<EnemyHealthHandler>();
		if (enemyHpScript != null)
		{
			enemyHpScript.ModifyHp(-damage);
		}
	}
}
