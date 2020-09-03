using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using alexM;
using Mirror.Examples.NetworkRoom;
using Mirror.Examples.Pong;
using Niall;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace AnthonyY
{
    public class CanSeePlayerAction : ReGoapAction<string,object>
{
    public bool        canSeePlayer = false;
	public LineOfSight _lineofSight;

    protected override void Awake()
    {
        base.Awake();
    }
    
    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        //its successful
        doneCallback(this);
    }

	public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
	{
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
		// //Action Code
		if (_lineofSight.CheckLOS())
		{
			Debug.Log("I detected player!");
		
			effects.Set("canSeePlayer", true);
		}
		else
		{
			effects.Set("canSeePlayer", false);
		}

        // effects.Set("Bezerker",true);
        return base.GetEffects(stackData);
    }

    public override bool CheckProceduralCondition(GoapActionStackData<string, object> stackData)
    {
        return true;
    }

    //Record the action into the memory
    public override void Exit(IReGoapAction<string, object> next)
    {
        base.Exit(next);
        var worldState = agent.GetMemory().GetWorldState();
    
        foreach (var pair in effects.GetValues())
        {
            worldState.Set(pair.Key,pair.Value);
        }
    }
}

}
