using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity entity;
    
    
    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRW<Speed> speed;

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(speed.ValueRO.direction - _transform.ValueRO.Position);
        _transform.ValueRW.Position += direction * deltaTime * speed.ValueRO.value;
        
    }

    public void TestReachedTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = 0.5f;
        if (math.distance(_transform.ValueRO.Position, speed.ValueRO.direction) < reachedTargetDistance)
        {
            speed.ValueRW.direction= GetRandomPosition(randomComponent);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> random )
    {
        
        return new float3(random.ValueRW.random.NextFloat(0f, 15f), 0, random.ValueRW.random.NextFloat(0f, 15f));
    }
    
    


}
