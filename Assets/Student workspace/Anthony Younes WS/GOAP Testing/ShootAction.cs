using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AJ;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace AnthonyY
{
    public class ShootAction : ReGoapAction<string,object>
{
    public Gun pistol;
    public bool isShooting = true;
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);

    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        base.Run(previous, next, settings, goalState, done, fail);
        if (isShooting)
        {
            Debug.Log("I am shooting the enemy");
            doneCallback(this);
        }
        else if(!isShooting)
        {
            failCallback(this);
        }
    }

    public override void PlanEnter(IReGoapAction<string, object> previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
    {
        base.PlanEnter(previousAction, nextAction, settings, goalState);
    }

    public override void PlanExit(IReGoapAction<string, object> previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
    {
        base.PlanExit(previousAction, nextAction, settings, goalState);
    }

    public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        preconditions.Set("canMoveTowardsPlayer",true);
        return base.GetPreconditions(stackData);
    }

    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        if (isShooting)
        {
            effects.Set("killGuy",true);
            effects.Set("canSeePlayer",false);
        }
        return base.GetEffects(stackData);
    }

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
