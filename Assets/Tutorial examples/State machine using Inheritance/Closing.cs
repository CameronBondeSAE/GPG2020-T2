using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : StateBase
{
	public override void Enter()
	{
		// base.Enter();
		Debug.Log("Closing enter");
	}

	public override void Execute()
	{
		// base.Execute();
		Debug.Log("Closing: Execute");
	}

	public override void Exit()
	{
		// base.Exit();
		Debug.Log("Closing: Exit");
	}
}
