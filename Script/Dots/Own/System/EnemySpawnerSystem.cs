using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(SpampleSceneSystemGroup))]
public partial struct EnemySpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.Enabled = false;
        state.RequireForUpdate<EnemyGenerator>();
    
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {    
    
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var graveyardEntity = SystemAPI.GetSingletonEntity<EnemyGenerator>();
        var graveyard = SystemAPI.GetAspect<GraveyardAspect>(graveyardEntity);

        var ecb = new EntityCommandBuffer();

        for (int i = 0; i < graveyard.NumberombstoneToSpawn; i++)
        {
            var newEnemy= ecb.Instantiate(graveyard.enemyPrefad);

            var localtrnasform = SystemAPI.GetComponentRW<LocalTransform>(newEnemy);
            localtrnasform.ValueRW.Position = graveyard.RandomPosition();
            localtrnasform.ValueRW.Rotation=quaternion.identity;
            localtrnasform.ValueRW.Scale = 1f;
        }
        ecb.Playback(state.EntityManager);
        state.Enabled = false;

    }
}        
