using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : TopDownCarController
{
	public Vector2 target { private get; set; }

	/*protected override void ApplySteering(float _steeringInput)
	{
		rotationAngle -= _steeringInput * carData.turnFactor;
		var heading = target + (Vector2)transform.position;

		var rotation = Quaternion.LookRotation(heading);
		carRigidbody2D.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, carData.turnFactor));
	}*/

	public void SetRotation(Vector2 _direction){
		carRigidbody2D.MoveRotation(Vector2.Angle(transform.up,_direction));
	}
}
