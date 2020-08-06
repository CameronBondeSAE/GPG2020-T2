using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class KillGuyGoal : ReGoapGoal<string,object>
{
    protected override void Awake()
    {
        base.Awake();
        goal.Set("killGuy",true);
    }
}
