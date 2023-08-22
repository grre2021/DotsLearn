using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
[RequireMatchingQueriesForUpdate]
public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        /*
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        foreach (var moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime,randomComponent);
        }
        */
       
    }
}
