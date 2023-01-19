using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	[SerializeField] private GameObject pickup;
	[SerializeField] private SpawnArea spawnArea;
	[SerializeField] private float checkRadius;
	[SerializeField] private LayerMask checkLayers;

	// Start is called before the first frame update
	void Start()
	{
		Spawn();
	}

	void Spawn()
	{

		var _pickupSpot = spawnArea.GetSpawnPoint();
		int i = 0;
		while (Physics2D.OverlapCircleAll(_pickupSpot, checkRadius, checkLayers).Length>0&&i<1000)
		{
			_pickupSpot = spawnArea.GetSpawnPoint();
			i++;
		}
		var _pickup=Instantiate(pickup, spawnArea.GetSpawnPoint(), Quaternion.identity);
		_pickup.GetComponent<ShieldPickup>().OnPickup += OnPickupSpawn;
	}

	private void OnPickupSpawn(object sender, EventArgs e)
	{
		Spawn();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		foreach (var _area in spawnArea.spawnAreas)
		{
			Gizmos.DrawWireCube(_area.Center.position, new Vector3(_area.HorizontalExtend * 2, _area.VerticalExtend * 2, 0.01f));
		}

		Gizmos.DrawWireSphere(transform.position, checkRadius);
	}
}
