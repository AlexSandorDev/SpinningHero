using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpringEntity : MonoBehaviour
{
	[field: SerializeField] public SpringEnum springTag { get; private set; } = SpringEnum.melee;
	private void Start()
	{
		if (springTag == SpringEnum.overrideE)
		{
			GameManager.OverrideSprings.Concat(GetComponents<SpringComponent>());
			return;
		}

		GameManager.EntityDict[springTag].Add(this);
	}

	void OnDestroy()
	{
		if (springTag == SpringEnum.overrideE) return;

		GameManager.EntityDict[springTag].Remove(this);
	}
}

[System.Serializable]
public enum SpringEnum
{
	overrideE,
	player,
	melee,
	danger,
	solid,
	pickup
}
