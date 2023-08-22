using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(SpampleSceneSystemGroup))]
[UpdateAfter(typeof(EmenyGenerateSystem))]
public partial struct EnemyChashingSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        var job = new EnemyChashingIJob()
        {
            DeltaTime = SystemAPI.Time.DeltaTime
            
        };
        job.ScheduleParallel();
        
    }
}
