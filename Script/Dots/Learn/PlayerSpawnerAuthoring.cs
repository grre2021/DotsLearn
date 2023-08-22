using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PlayerSpawnerComponent : IComponentData
{
    public Entity playerPrefad;
}
public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject playerPrefad;
}

 public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        AddComponent(new PlayerSpawnerComponent
            {
                playerPrefad =GetEntity(authoring.playerPrefad),
            }
            );
    }
}