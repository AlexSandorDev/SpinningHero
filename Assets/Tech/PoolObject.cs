using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
	private void Awake()
	{
		layer = this.gameObject.layer;
	}

	private void Start()
	{
		OnSpawn();
	}

	public abstract void OnSpawn();

	public abstract LayerMask? layer { get; set; }
}
