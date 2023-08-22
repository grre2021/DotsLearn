using Unity.Entities;
using UnityEngine;

public struct ShootAthoring : IComponentData
{
    public Entity bullet;
}

public struct ShootTag : IComponentData,IEnableableComponent
{
    
}

public class ShootAthoringAuthoring : Singleton<ShootAthoringAuthoring>
{
    public GameObject bulletPrefad;
    public class Baker : Baker<ShootAthoringAuthoring>
    {
        public override void Bake(ShootAthoringAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var data = new ShootAthoring
            {  
                bullet = GetEntity(authoring.bulletPrefad, TransformUsageFlags.Dynamic)
            };
            
            AddComponent(entity,new ShootTag());
            AddComponent(entity,data);
            SetComponentEnabled<ShootTag>(entity,false);
            
        }
    }
}
