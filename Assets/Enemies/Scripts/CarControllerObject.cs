using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controller Data", menuName = "ScriptableObjects/Controller Data")]
public class CarControllerObject : ScriptableObject
{
	[Header("Acceleration")]
	public float accelerationFactor = 30.0f;
	public float maxSpeed = 20;
	[Header("Brakes")]
	public float decelerationFactor = 60.0f;
	public float maxReverseSpeed = 5;
	public float reverseAccelerationFactor = 60.0f;
	[Header("Turning")]
	[Range(0, 1)]
	public float driftFactor = 0.95f;
	[field: SerializeField] public float turnFactor { get; private set; } = 3.5f;
	public float turnAcceleration = 2.0f;
}
