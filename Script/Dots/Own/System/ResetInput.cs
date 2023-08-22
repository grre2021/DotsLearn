using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

[BurstCompile]
[RequireMatchingQueriesForUpdate]
[UpdateInGroup(typeof(SpampleSceneSystemGroup),OrderLast = true)]
[UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
public partial struct ResetInput : ISystem
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
            
        foreach (var (tag, entity) in SystemAPI.Query<ShootTag>().WithEntityAccess())
        {
            ecb.SetComponentEnabled<ShootTag>(entity, false);
        }
            
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}        
