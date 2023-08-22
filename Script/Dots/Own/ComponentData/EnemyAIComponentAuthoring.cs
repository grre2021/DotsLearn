using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

struct EnemyAIComponent : IComponentData
{
    public float chashingSpeed;
    public float3 target;

}

public class EnemyAIComponentAuthoring : MonoBehaviour
{
    public float chashingSpeed=1;
    public float3 target=new float3(0,0,0);
    public class Baker : Baker<EnemyAIComponentAuthoring>
    {
        public override void Bake(EnemyAIComponentAuthoring authoring)
        {
            var data = new EnemyAIComponent
            {  
                chashingSpeed = authoring.chashingSpeed,
                target = authoring.target
            };
            AddComponent(data);
        }
    }
}
