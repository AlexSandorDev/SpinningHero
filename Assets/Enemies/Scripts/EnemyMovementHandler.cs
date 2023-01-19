using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class EnemyMovementHandler : EnemyHandlers
{
	public abstract void StartRotating(Vector2 _target);
	public abstract void StopRotating();


	public abstract void StartMoving(Vector2 _target);
	public abstract void StopMoving();

}
