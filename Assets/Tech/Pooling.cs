using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

public class Pooling : MonoBehaviour
{
	[SerializeField] LayerMask deactivatedLayer;

	public static Pooling pooling;

	private int deactivatedLayerValue;

	public enum PoolTags
	{
		Goblin,
		Lancer
	}

	private void Awake()
	{
		poolDictionary = new Dictionary<PoolTags, Queue<GameObject>>();

		pooling = this;

		deactivatedLayerValue = LayermaskToLayer(deactivatedLayer);

		foreach (var pool in pools)
		{
			Queue<GameObject> objPool = new Queue<GameObject>();

			for (int i = 0; i < pool.numberOfObjects; i++)
			{
				var obj = Instantiate(pool.prefab);
				obj.layer = deactivatedLayerValue;
				obj.SetActive(false);
				objPool.Enqueue(obj);
			}

			poolDictionary.Add(pool.tag, objPool);
		}

	}
	private static int LayermaskToLayer(LayerMask layerMask)
	{
		int layerNumber = 0;
		int layer = layerMask.value;
		while (layer > 0)
		{
			layer = layer >> 1;
			layerNumber++;
		}
		return layerNumber - 1;
	}

	public Dictionary<PoolTags, Queue<GameObject>> poolDictionary;
	public List<Pool> pools;

	#region Spawn
	public GameObject Spawn(PoolTags tag, Vector2 position, Transform? parent, Quaternion? rotation)
	{
		var objectToSpawn = SpawnMethod(tag, position);

		objectToSpawn.transform.parent = parent;

		if (rotation != null)
			objectToSpawn.transform.rotation = rotation.Value;

		OnSpawn(objectToSpawn);

		return objectToSpawn;
	}

	public GameObject Spawn(PoolTags tag, Vector2 position)
	{
		return Spawn(tag, position, null, null);
	}

	public GameObject Spawn(PoolTags tag, Vector2 position, Transform? parent)
	{
		return Spawn(tag, position, parent, null);
	}

	public GameObject Spawn(PoolTags tag, Vector2 position, Quaternion? rotation)
	{
		return Spawn(tag, position, null, rotation);
	}

	private GameObject SpawnMethod(PoolTags tag, Vector2 position)
	{
		{
			if (!poolDictionary.ContainsKey(tag))
			{
				Debug.LogWarning("Pooling with tag " + tag + " doens't exist");
				return null;
			}

			GameObject objectToSpawn = poolDictionary[tag].Dequeue();

			objectToSpawn.SetActive(true);
			objectToSpawn.transform.position = position;

			poolDictionary[tag].Enqueue(objectToSpawn);

			var pooledObject = objectToSpawn.GetComponents<PoolObject>()[0];

			if (pooledObject != null)
			{
				if (pooledObject.layer != null)
					objectToSpawn.gameObject.layer = pooledObject.layer.Value;
				else
					pooledObject.layer = objectToSpawn.gameObject.layer;
			}

			return objectToSpawn;
		}
	}

	private void OnSpawn(GameObject objectToSpawn)
	{
		var pooledObjects = objectToSpawn.GetComponents<PoolObject>();
		if (pooledObjects != null)
		{
			foreach (var obj in pooledObjects)
				obj.OnSpawn();
		}
	}

	#endregion

	public void Destroy(GameObject obj)
	{
		obj.layer = deactivatedLayerValue;
		obj.SetActive(false);
	}
}
