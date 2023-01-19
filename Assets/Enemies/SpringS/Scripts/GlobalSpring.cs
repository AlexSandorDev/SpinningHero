using System;
using UnityEngine;

[System.Serializable]
public class GlobalSpring : SpringComponent
{
	private void Start()
	{
		try
		{
			Data.OverMinAttraction = Mathf.Clamp(Data.OverMinAttraction, -1, 1);
		}
		catch (NullReferenceException)
		{
			Debug.LogError("No Spring Data Object Added");
		}
	}

	protected override Vector2 SpringEval(Vector2 targetPosition)
	{
		var _dist = Vector2.Distance(checkOriginPoint.position, targetPosition);
		var _vector = (targetPosition - (Vector2)transform.position).normalized;

		if (_dist > Data.MinDistance && _dist < Data.MaxDistance)
		{
			_vector *= Data.OverMinAttraction;
		}
		else
		{
			_vector *= Data.UnderMinAttraction;
		}

		return _vector;
	}
}
