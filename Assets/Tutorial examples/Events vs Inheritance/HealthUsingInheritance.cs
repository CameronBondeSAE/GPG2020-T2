using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUsingInheritance : MonoBehaviour
{
	public float health;

	// Note the keyword "virtual". To customise this for each object, the object makes a new script that inherits from this (see BarrelHealth)
	public virtual void Die()
	{
	}
}
