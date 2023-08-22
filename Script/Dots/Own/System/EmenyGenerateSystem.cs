using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(SpampleSceneSystemGroup))]
public partial struct EmenyGenerateSystem : ISystem
{
    private float timer;
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
        // 在加载EnemyGenerator之前，不应该运行此系统
        state.RequireForUpdate<EnemyGenerator>();
        timer = 0f;
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        var generator = SystemAPI.GetSingleton<EnemyGenerator>();
       // var generatorEntity = SystemAPI.GetSingletonEntity<EnemyGenerator>();
        var random = SystemAPI.GetSingleton<GraveyardRandom>();
        timer += SystemAPI.Time.DeltaTime;
        if(timer<generator.generatorTime) return;
        //Debug.Log(generator.count);
        var enemys = CollectionHelper.CreateNativeArray<Entity>(generator.count, Allocator.Temp);
        state.EntityManager.Instantiate(generator.enemyProtoType, enemys);
        int count=0;
        foreach (var variableEnemy in enemys)
        {
            Debug.Log("Generate");
            
            state.EntityManager.AddComponentData<EnemyComponentData>(variableEnemy, new EnemyComponentData
            {
                chashSpeed = generator.chashingSpeed,
                shootingDistance = 3f,
                targetPosition = new float3(2, 3, 1)

            });
            
            //var position = new float3(count  * 1.2f, 0, 0);
            var localTransform = SystemAPI.GetComponentRW<LocalTransform>(variableEnemy);
            float3 HalfDismosion = new float3()
            {
                x = generator.filedDimensions.x * 0.5f,
                y = 0f,
                z = generator.filedDimensions.y * 0.5f
            };
            float3 min = localTransform.ValueRO.Position - HalfDismosion;
            float3 max = localTransform.ValueRO.Position + HalfDismosion;
            float3 position = random.value.NextFloat3(min, max);
            localTransform.ValueRW.Position = position;
            localTransform.ValueRW.Rotation = quaternion.RotateY(-90f);
           
            localTransform.ValueRW.Scale = 1;
            count++;

        }
        enemys.Dispose();
        state.Enabled = false;




    }
}
