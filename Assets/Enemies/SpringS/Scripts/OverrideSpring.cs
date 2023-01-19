using UnityEngine;

public class OverrideSpring : SpringComponent
{
	protected override Vector2 SpringEval(Vector2 _targetPosition)
	{
		throw new System.NotImplementedException();
	}
}