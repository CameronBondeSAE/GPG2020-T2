using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class ShootyGuyMemory : ReGoapMemory<string,object>
{
    public bool isEnemyDead = false;
    public bool checkSeePlayer = false;
    public bool canIFling = false;


    protected override void Awake()
    {
        base.Awake();
        GetWorldState().Set("KillGuy",isEnemyDead);
        GetWorldState().Set("canSeePlayer",checkSeePlayer);
        GetWorldState().Set("Bezerker",canIFling);
    }
}
