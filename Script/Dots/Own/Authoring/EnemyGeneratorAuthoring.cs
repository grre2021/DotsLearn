using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public struct EnemyGenerator : IComponentData
{
    public float2 filedDimensions;
    public Entity enemyProtoType;
    public int count;
    public float generatorTime;
    public float chashingSpeed;
}
public class EnemyGeneratorAuthoring : MonoBehaviour
{
    public float2 filedDimensions;
    public GameObject enemyPrefad;
    public int count;
    public float generatorTime;
    public float chashingSpeed;
    
    
    private class EnemyGeneratorBaker : Baker<EnemyGeneratorAuthoring>
    {
        public override void Bake(EnemyGeneratorAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity,new EnemyGenerator
                {
                    filedDimensions = authoring.filedDimensions,
                    enemyProtoType = GetEntity(authoring.enemyPrefad,TransformUsageFlags.Dynamic),
                    count = authoring.count,
                    generatorTime = authoring.generatorTime,
                    chashingSpeed = authoring.chashingSpeed
                    
                }
                );
        }
    }
    
}
