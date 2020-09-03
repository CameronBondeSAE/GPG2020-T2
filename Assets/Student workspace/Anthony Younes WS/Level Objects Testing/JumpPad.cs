using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class JumpPad : NetworkBehaviour
{
	public int  thrustX, thrustY, thrustZ;
	public bool relativeToRotation = false;

	public bool resetVelocity = false;
	// public bool useTrigger         = true;

	// public void OnCollisionEnter(Collision other)
	// {
	// 	Jump(other.collider);
	// }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Gameplay relevant colliders"))
		{
			Jump(other);
		}
	}

	private void Jump(Collider other)
	{
		Vector3 gameThrust = new Vector3(thrustX, thrustY, thrustZ);
		// if (isServer)
		// {
		Rigidbody rb = other.transform.root.GetComponent<Rigidbody>();
		
		if (rb != null)
		{
			Vector3 rbVelocity = rb.velocity;
			
			if (relativeToRotation)
			{
				Vector3 transformRotation = transform.rotation * gameThrust;
				
				if (resetVelocity)
				{
					rb.velocity = gameThrust;
					rb.velocity = new Vector3(gameThrust.x < 0.01f ? rbVelocity.x : transformRotation.x, gameThrust.y < 0.01f ? rbVelocity.y : transformRotation.y, gameThrust.z < 0.01f ? rbVelocity.z : transformRotation.z);
				}
				else
				{
					rb.AddForce(transformRotation, ForceMode.VelocityChange);
				}
			}
			else
			{
				if (resetVelocity)
				{
					rb.velocity = gameThrust;
					rb.velocity = new Vector3(gameThrust.x < 0.01f ? rbVelocity.x : rb.velocity.x, gameThrust.y < 0.01f ? rbVelocity.y : rb.velocity.y, gameThrust.z < 0.01f ? rbVelocity.z : rb.velocity.z);
				}
				else
				{
					rb.AddForce(gameThrust, ForceMode.VelocityChange);
				}
			}
		}

		// }
	}
}