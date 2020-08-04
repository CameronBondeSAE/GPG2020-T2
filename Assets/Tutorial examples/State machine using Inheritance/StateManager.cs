using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public StateBase currentState;
	
	public void ChangeState(StateBase newState)
	{
		// Check if newState is different
		currentState.Exit();
		newState.Enter();
		currentState = newState;
	}

	public void Update()
	{
		currentState?.Execute();
	}
}
