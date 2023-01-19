using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SpawnArea
{
	[field: SerializeField] public List<spawnArea> spawnAreas { get; private set; }

	public Vector2 GetSpawnPoint()
	{
		var _area = spawnAreas[Random.Range(0, spawnAreas.Count)];
		var _maxLimit = new Vector2(_area.Center.position.x + _area.HorizontalExtend, _area.Center.position.y + _area.VerticalExtend);
		var _minLimit = new Vector2(_area.Center.position.x - _area.HorizontalExtend, _area.Center.position.y - _area.VerticalExtend);

		return new Vector2(Random.Range(_minLimit.x, _maxLimit.x), Random.Range(_minLimit.y, _maxLimit.y));
	}
}

[System.Serializable]
public struct spawnArea
{
	public Transform Center;
	public float VerticalExtend;
	public float HorizontalExtend;
}
