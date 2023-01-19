using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHandler : PoolObject
{
	public BasicEnemyScriptableObject enemyObj;
	[HideInInspector]
	public EnemyCarController movement;
	[HideInInspector]
	public MeleEnemyInput input;

	public override LayerMask? layer { get; set; }

	public override void OnSpawn()
	{
	}

	private void Start()
	{
		movement = GetComponent<EnemyCarController>();
		input = GetComponent<MeleEnemyInput>();

		movement.carData = enemyObj.carData;
		input.turnFactor = enemyObj.carData.turnFactor;
	}
}
