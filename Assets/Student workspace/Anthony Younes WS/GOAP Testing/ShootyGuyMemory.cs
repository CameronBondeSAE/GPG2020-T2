using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class ShootyGuyMemory : ReGoapMemory<string,object>
{
    public bool canShoot = false;
    public bool isEnemyDead = false;
    public bool checkSeePlayer = false;
    public bool canPatrol = true;


    protected override void Awake()
    {
        base.Awake();
        GetWorldState().Set("canShoot",canShoot);
        GetWorldState().Set("isEnemyDead",isEnemyDead);
        GetWorldState().Set("checkSeePlayer",checkSeePlayer);
        GetWorldState().Set("canPatrol",canPatrol);
    }
}
