using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class JumpPad : NetworkBehaviour
{
	public int  thrustX, thrustY, thrustZ;
	public bool relativeToRotation = false;
	public bool useTrigger         = true;

	public void OnCollisionEnter(Collision other)
	{
		Jump(other.collider);
	}

	private void OnTriggerEnter(Collider other)
	{
		Jump(other);
	}

	private void Jump(Collider other)
	{
		Vector3 gameThrust = new Vector3(thrustX, thrustY, thrustZ);
		// if (isServer)
		// {
		if (other.transform.root.GetComponent<Rigidbody>() != null)
		{
			if (relativeToRotation)
			{
				other.transform.root.GetComponent<Rigidbody>().AddForce(transform.rotation * gameThrust, ForceMode.VelocityChange);
			}
			else
			{
				other.transform.root.GetComponent<Rigidbody>().AddForce(gameThrust, ForceMode.VelocityChange);
			}
		}

		// }
	}
}