using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitVeloci : MonoBehaviour
{
	[SerializeField] private float maxVelocity;
	Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (rb.velocity.magnitude <= maxVelocity) return;

		rb.velocity = rb.velocity.normalized * maxVelocity;
	}
}
