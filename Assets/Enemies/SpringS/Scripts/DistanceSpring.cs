using UnityEngine;

[System.Serializable]
public class DistanceSpring : SpringComponent
{
	private void Start()
	{
		if (Data != null) Data.OverMinAttraction = Mathf.Clamp(Data.OverMinAttraction, -1, 1);
	}

	protected override Vector2 SpringEval(Vector2 targetPosition)
	{
		var _dist = Vector2.Distance(checkOriginPoint.position, targetPosition);
		var _vector = (targetPosition - (Vector2)transform.position).normalized;

		var _lerping = _dist >= 1 ? _dist : 1;


		if (_dist > Data.MinDistance && _dist < Data.MaxDistance)
		{
			_vector *= Data.OverMinAttraction / _lerping;
		}
		else
		{
			_vector *= -Data.UnderMinAttraction / _lerping;
		}

		return _vector;
	}
}
