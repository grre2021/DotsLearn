using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Random= Unity.Mathematics.Random;
public class RandomSingletonAuthoring : Singleton<RandomSingletonAuthoring>
{
    public uint seed = 1;
    public class Baker : Baker<RandomSingletonAuthoring>
    {
        public override void Bake(RandomSingletonAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            var data = new  GraveyardRandom
            {
                value= new Random(authoring.seed)
            };
            AddComponent(entity,data);
        }
    }
}
