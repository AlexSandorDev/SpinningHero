using UnityEngine;

[System.Serializable]
public abstract class MovementTargetingHandler : EnemyHandlers
{
	public abstract Vector2 GetTargetPosition();
}