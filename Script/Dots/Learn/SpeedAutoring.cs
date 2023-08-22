using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpeedAutoring : MonoBehaviour
{
   public float value;
   public float3 direction;
}

public class BAKERNAME : Baker<SpeedAutoring>
{
   public override void Bake(SpeedAutoring authoring)
   {
      AddComponent(new Speed
      {
         value = authoring.value,
         direction = authoring.direction
         
      });
   }
}