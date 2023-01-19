using System;
using UnityEngine;

[Serializable]
public abstract class SpringComponent : MonoBehaviour
{
	[field: SerializeField] public SpringData Data { get; protected set; }
	[field: SerializeField] protected Transform checkOriginPoint { get; private set; }

	protected abstract Vector2 SpringEval(Vector2 _targetPosition);

	protected void Awake()
	{
		if (checkOriginPoint == null) checkOriginPoint = transform;
	}

	public Vector2 Evaluate()
	{
		var _finalVector = Vector2.zero;

		foreach (var entity in GameManager.EntityDict[Data.SpringTag])
		{
			_finalVector += SpringEval(entity.transform.position);
			_finalVector.Normalize();
		}

		return _finalVector;
	}

	protected void OnDrawGizmosSelected()
	{
		if (Data == null) return;
		if (checkOriginPoint == null) checkOriginPoint = transform;
		Gizmos.color = Data.MaxColor;
		Gizmos.DrawWireSphere(checkOriginPoint.position, Data.MaxDistance);

		Gizmos.color = Data.MinColor;
		Gizmos.DrawWireSphere(checkOriginPoint.position, Data.MinDistance);
	}

}
