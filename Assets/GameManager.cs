using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour, ISerializationCallbackReceiver
{
	public static Transform playerTransform;
	public static ScoreHandler scoreHandler;
	public EnemySpawner enemySpawner;


	public static Dictionary<SpringEnum, List<SpringEntity>> EntityDict { get; private set; }
	public static List<SpringComponent> OverrideSprings;

	[SerializeField] private Transform PlayerTransform;                  //used only for serialization
	[SerializeField] private ScoreHandler ScoreHandler;
	[SerializeField] private EnemySpawner EnemySpawner;

	private void Awake()
	{
		EntityDict = new Dictionary<SpringEnum, List<SpringEntity>>();
		OverrideSprings = new List<SpringComponent>();

		foreach (var tag in Enum.GetValues(typeof(SpringEnum)).Cast<SpringEnum>())
		{
			EntityDict.Add(tag, new List<SpringEntity>());
		}
	}

	public void OnAfterDeserialize()
	{
		playerTransform = PlayerTransform;
		scoreHandler = ScoreHandler;
		enemySpawner = EnemySpawner;
	}

	public void OnBeforeSerialize()
	{
		PlayerTransform = playerTransform;
		ScoreHandler = scoreHandler;
		EnemySpawner = enemySpawner;
	}

	public static event EventHandler<OnEnemyDeathArgs> onEnemyDeath;
	public class OnEnemyDeathArgs : EventArgs
	{
		public int scoreIncrease;
	}

	public static void OnEnemyDeath(object sender, OnEnemyDeathArgs args)
	{
		onEnemyDeath?.Invoke(sender, args);
	}
}
