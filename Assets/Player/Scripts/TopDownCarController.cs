using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
	public CarControllerObject carData;

	//Local variables
	float accelerationInput = 0;
	float steeringInput = 0;

	protected float rotationAngle = 0;

	float velocityVsUp = 0;

	//Components
	protected Rigidbody2D carRigidbody2D;

	//Awake is called when the script instance is being loaded.
	void Awake()
	{
		carRigidbody2D = GetComponent<Rigidbody2D>();
	}

	//Frame-rate independent for physics calculations.
	void FixedUpdate()
	{
		if (carData == null) return;

		ApplyEngineForce();

		KillOrthogonalVelocity();

		ApplySteering(steeringInput);
	}

	void ApplyEngineForce()
	{
		if (accelerationInput == 0)
			carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
		else carRigidbody2D.drag = 0;

		var accel = accelerationInput > 0 ? carData.accelerationFactor : accelerationInput == 0 ? carData.turnAcceleration : -carData.decelerationFactor;

		if (carData.accelerationFactor < 0 && carRigidbody2D.velocity.y < 0) accel = carData.reverseAccelerationFactor;

		velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

		if (velocityVsUp > carData.maxSpeed && accelerationInput > 0)
			return;
		if (velocityVsUp < -carData.maxReverseSpeed && accelerationInput < 0)
			return;
		if (carRigidbody2D.velocity.sqrMagnitude > carData.maxSpeed * carData.maxSpeed && accelerationInput > 0)
			return;

		Vector2 engineForceVector = transform.up * accel;

		carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
	}

	protected virtual void ApplySteering(float _steeringInput)
	{
		rotationAngle -= _steeringInput * carData.turnFactor; 
		
		carRigidbody2D.MoveRotation(rotationAngle);
	}

	void KillOrthogonalVelocity() //side velocity
	{
		Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
		Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

		carRigidbody2D.velocity = forwardVelocity + rightVelocity * carData.driftFactor;
	}

	float GetLateralVelocity()
	{
		return Vector2.Dot(transform.right, carRigidbody2D.velocity);
	}

	public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
	{
		lateralVelocity = GetLateralVelocity();
		isBraking = false;

		if (accelerationInput < 0 && velocityVsUp > 0)
		{
			isBraking = true;
			return true;
		}

		if (Mathf.Abs(GetLateralVelocity()) > 4.0f)
			return true;

		return false;
	}

	public void SetInput(float steering, float acceleration)
	{
		steeringInput = steering;
		accelerationInput = acceleration;
	}

	public float GetVelocityMagnitude()
	{
		return carRigidbody2D.velocity.magnitude;
	}
}
