using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Opening : StateBase
{
	public AudioSource  AudioSource;
	public StateManager stateManager;
	public StateBase    stateToChangeTo;
	public bool         iveGottenToTheEnd = false;
	
	public override void Enter()
	{
		// base.Enter();
		Debug.Log("Opening: Enter");
		AudioSource.Play();
	}

	public override void Execute()
	{
		// base.Execute();
		Debug.Log("Opening: Execute");

		if (iveGottenToTheEnd)
		{
			stateManager.ChangeState(stateToChangeTo);
		}
	}

	public override void Exit()
	{
		// base.Exit();
		
		Debug.Log("Opening: Exit");
	}
}
