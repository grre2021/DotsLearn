using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
public readonly partial struct GraveyardAspect : IAspect
{
  public readonly Entity Entity;

  private readonly RefRW<LocalTransform> _transform;

  private readonly RefRO<EnemyGenerator> _enemyGenerator;

  private readonly RefRW<GraveyardRandom> _graveyardRandom;

  public int NumberombstoneToSpawn => _enemyGenerator.ValueRO.count;

  public Entity enemyPrefad => _enemyGenerator.ValueRO.enemyProtoType;

  public float3 RandomPosition()
  {
      float3 randomPosition;
      randomPosition = _graveyardRandom.ValueRW.value.NextFloat3(MinCorner, MaxCorner);
      return randomPosition;
  }

  private float3 MinCorner => _transform.ValueRO.Position - HalfDimenSions;
  private float3 MaxCorner => _transform.ValueRO.Position + HalfDimenSions;

  private float3 HalfDimenSions => new()
  {
      x = _enemyGenerator.ValueRO.filedDimensions.x * 0.5f,
      y = 0f,
      z = _enemyGenerator.ValueRO.filedDimensions.y * 0.5f
  };
}
