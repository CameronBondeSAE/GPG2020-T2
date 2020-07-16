using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelUsingCodeToSubscribe : MonoBehaviour
{
	public HealthUsingEvents health;

	private void Awake()
	{
		// Use code instead of the inspector to hook it up
		health.dieEvent.AddListener(ThingToDoWhenIDie);
	}

	private void OnDestroy()
	{
		// This one cleans up better than the inspector (inspector leaves empty entries in the UI when things get destroyed)
		health.dieEvent.RemoveListener(ThingToDoWhenIDie);
	}

	public void ThingToDoWhenIDie()
	{
		Debug.Log("I'm a barrel using code to subscribe to health events... and I'm dead now");
		Destroy(gameObject);
	}
}