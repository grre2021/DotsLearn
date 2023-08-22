using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
partial struct EnemyChashingIJob :IJobEntity
{
    public float DeltaTime;
    public void Execute(Entity entity,EnemyChashingAspect aspect)
    {
        aspect.Chashing(DeltaTime);
       
    }
}
