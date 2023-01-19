using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SpringHandler
{
	[SerializeField] public List<SpringComponent> springs;

	Vector2 previousVector = Vector2.zero;
	float lerp = 1f;

	public SpringHandler(List<SpringComponent> _springs)
	{
		springs = _springs.Concat(GameManager.OverrideSprings).ToList();
	}

	public Vector2 CalculateDirectionVector()
	{
		var _vector = Vector2.zero;
		foreach (var spring in springs)
		{
			_vector += spring.Evaluate();
		}

		//_vector = Vector2.Lerp(previousVector, _vector.normalized, lerp*Time.deltaTime).normalized;
		previousVector = _vector;

		return _vector.normalized;
	}
}
