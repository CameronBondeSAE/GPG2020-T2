using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthUsingCSharpEvents : MonoBehaviour
{
	public float current;
	
	public event Action dieEvent;

	public void Die()
	{
		dieEvent?.Invoke();
	}
}
