using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class GoapGoal1 : ReGoapGoal<string, object>
{
    protected override void Awake()
    {
        goal.Set("doneAction", true);
    }
}
