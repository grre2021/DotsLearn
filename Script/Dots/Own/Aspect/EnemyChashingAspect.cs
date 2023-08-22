using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

readonly partial struct EnemyChashingAspect : IAspect
{
   private readonly RefRW<LocalTransform> localTransform;
   private readonly RefRO<EnemyAIComponent> _enemyAIComponentq;
   
   
   public void Chashing(float deltaTime)
   {
      // Debug.Log(localTransform.ValueRW.Rotation);
      // localTransform.ValueRW.Rotation=quaternion.LookRotation(localTransform.ValueRO.Position,
               //   _enemyAIComponentq.ValueRO.target);
               
               localTransform.ValueRW.Rotation =
                   Quaternion.LookRotation(_enemyAIComponentq.ValueRO.target);

   }
}
