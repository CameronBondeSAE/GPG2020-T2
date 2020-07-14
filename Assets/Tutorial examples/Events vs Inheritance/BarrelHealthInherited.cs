using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHealthInherited : HealthUsingInheritance
{
	// This will get called from any code telling the Health component to Die (including health itself)
	public override void Die()
	{
		base.Die();

		Debug.Log("I'm a barrel using inheritance to override the die function... and I'm dead now");
		Destroy(gameObject);
	}
}