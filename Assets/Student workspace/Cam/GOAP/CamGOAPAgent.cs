using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamGOAPAgent : ReGoapAgent<string, object>
{
	Dictionary<string, int> numbers = new Dictionary<string, int>();
	
	
	protected override void Start()
	{
		base.Start();

		numbers.Add("Cam", 666);
		numbers.Add("Doogle", 668);

		int value;

		if(!numbers.TryGetValue("Doofsfsdfgle", out value));
		{
			Debug.Log("NOT FOUND!");
		}
		Debug.Log(value);
	}

	private void Update()
	{
		if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		{
			CalculateNewGoal();
		}
	}
}
