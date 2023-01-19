using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandlers : MonoBehaviour
{
	protected EnemyHandler handler;

	private void Awake()
	{
		handler = GetComponent<EnemyHandler>();
	}
}
