using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


    struct RotateSpeed : IComponentData
    {
        public float rotateSpeed;
    }
    public class RotateSpeedAuthoring : MonoBehaviour
    {
        [Range(0, 360)]public float rotateSpeed = 360.0f;
        public class Baker : Baker<RotateSpeedAuthoring>
        {
            public override void Bake(RotateSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var data = new RotateSpeed
                {
                    rotateSpeed = math.radians(authoring.rotateSpeed)
                };
                AddComponent(entity,data);
            }
        }
    }

