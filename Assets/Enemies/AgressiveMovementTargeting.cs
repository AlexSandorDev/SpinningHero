using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMovementTargeting : MovementTargetingHandler
{
	public override Vector2 GetTargetPosition()
	{
		return GameManager.playerTransform.position;
	}
}
