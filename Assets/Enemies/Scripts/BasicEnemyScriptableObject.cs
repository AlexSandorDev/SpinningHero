using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Basic Enemy")]
public class BasicEnemyScriptableObject : EnemyScriptableObject
{
	public int MaxHp;
	public CarControllerObject carData;
}
