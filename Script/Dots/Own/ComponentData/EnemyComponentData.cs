using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct EnemyComponentData :IComponentData
{
    public float chashSpeed;
    public float shootingDistance;

    public float3 targetPosition;


}
