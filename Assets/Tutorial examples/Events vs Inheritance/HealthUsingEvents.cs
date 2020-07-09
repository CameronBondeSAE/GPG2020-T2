using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthUsingEvents : MonoBehaviour
{
	public float current;
	
	public UnityEvent dieEvent;

	public void Die()
	{
		dieEvent.Invoke();
	}
}
