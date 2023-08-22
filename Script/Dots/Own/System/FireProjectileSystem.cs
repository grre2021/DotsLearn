using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[RequireMatchingQueriesForUpdate]
[UpdateInGroup(typeof(SpampleSceneSystemGroup))]
public partial struct FireProjectileSystem : ISystem
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
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (shootPerfad,localTransform)in SystemAPI.Query<ShootAthoring,LocalTransform>().WithAll<ShootTag>())
        {
            var newShoot = ecb.Instantiate(shootPerfad.bullet);
            var projectileTransform = LocalTransform.FromPositionRotationScale
                (localTransform.Position+localTransform.Up()*3f, localTransform.Rotation, 1f);
            ecb.SetComponent(newShoot,projectileTransform);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    
    }
}        
