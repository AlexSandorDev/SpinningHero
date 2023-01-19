using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pooling;

[System.Serializable]
public class Pool
{
	public int numberOfObjects;
	public PoolTags tag;
	public GameObject prefab;
}