using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PlayerTag : IComponentData
{
    
}
public class PlayerAuthoring : MonoBehaviour
{
    
}

 public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        AddComponent(new PlayerTag());
    }
}
