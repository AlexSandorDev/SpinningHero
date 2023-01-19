using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pooling;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private float spawnTimer = 3f;
	[SerializeField] private float belowMaxSpawnTimer = 1f;
	[SerializeField] private PoolTags enemyTag;
	[SerializeField] private SpawnArea spawnArea;
	[SerializeField] private int maxEnemies = 5;

	private float currentSpawnTimer = 0;
	private int currentEnemies = 0;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Spawn());
		GameManager.onEnemyDeath += (x, y) => currentEnemies--;
	}

	IEnumerator Spawn()
	{
		pooling.Spawn(enemyTag, spawnArea.GetSpawnPoint());
		currentEnemies++;
		if (currentEnemies < maxEnemies)
		{
			currentSpawnTimer = belowMaxSpawnTimer;
		}
		else
		{
			currentSpawnTimer = spawnTimer;
		}
		yield return new WaitForSeconds(currentSpawnTimer);
		StartCoroutine(Spawn());
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		foreach (var _area in spawnArea.spawnAreas)
		{
			Gizmos.DrawWireCube(_area.Center.position, new Vector3(_area.HorizontalExtend * 2, _area.VerticalExtend * 2, 0.01f));
		}
	}
}



