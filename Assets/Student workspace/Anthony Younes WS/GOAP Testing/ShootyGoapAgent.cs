﻿using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootyGoapAgent : ReGoapAgent<string,object>
{
    // Update is called once per frame
    public void CalculateNewGoal()
    {
        //GetMemory().GetWorldState().Set("canShoot",true);
        CalculateNewGoal(true);
    }

    protected override bool CalculateNewGoal(bool forceStart = false)
    {
        
        return base.CalculateNewGoal(forceStart);
    }
}
 