using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;
using Unity.Rendering;
using UnityEngine;

public class ECSTestWobbleSystem : SystemBase
{
    
    protected override void OnUpdate()
    {
        double t = Time.ElapsedTime;
        Entities.ForEach((ref Translation position,in CubeComponentData cubeComponentData) =>
        {


            position.Value = new float3(position.Value.x,
                5 * noise.cnoise(new float2((float) t + (position.Value.x * 0.1f), 1)), position.Value.z);


        }).ScheduleParallel();
    }
}
