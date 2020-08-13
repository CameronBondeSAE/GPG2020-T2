using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class CamGOAPCheckHighHealthAction : ReGoapAction<string, object>
{
	public bool hasHighHealthDebug = true;

	protected override void Awake()
	{
		base.Awake();
		
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}

	public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
	{
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
		
		if (hasHighHealthDebug)
		{
			effects.Set("hasHighHealth", true);
		}
		else
		{
			effects.Set("hasHighHealth", false);
		}

		return base.GetEffects(stackData);
	}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
	{
		base.Run(previous, next, settings, goalState, done, fail);
		
		
	}


	public override void                        PostPlanCalculations(IReGoapAgent<string, object>            goapAgent)
	{
		base.PostPlanCalculations(goapAgent);
		
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}

	public override void                        Precalculations(GoapActionStackData<string, object>          stackData)
	{
		base.Precalculations(stackData);
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}

	public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object>         stackData)
	{
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
		return base.GetPreconditions(stackData);
	}

	public override bool                        CheckProceduralCondition(GoapActionStackData<string, object> stackData)
	{
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
		return base.CheckProceduralCondition(stackData);
	}

	public override void                        PlanEnter(IReGoapAction<string, object>                      previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
	{
		base.PlanEnter(previousAction, nextAction, settings, goalState);
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}

	public override void                        PlanExit(IReGoapAction<string, object>                       previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
	{
		base.PlanExit(previousAction, nextAction, settings, goalState);
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}

	public override void                        Exit(IReGoapAction<string, object>                           next)
	{
		base.Exit(next);
		Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
	}
}
