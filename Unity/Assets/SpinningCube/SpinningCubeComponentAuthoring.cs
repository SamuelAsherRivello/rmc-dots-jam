using Unity.Entities;
using UnityEngine;

public class SpinningCubeComponentAuthoring : MonoBehaviour
{
    public UnityEngine.Vector3 Speed;
    
    public class SpinningCubeComponentAuthoringBaker : Baker<SpinningCubeComponentAuthoring>
    {
        public override void Bake(SpinningCubeComponentAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<SpinningCubeComponent>(entity,
                new SpinningCubeComponent
                {
                    Speed = authoring.Speed
                    
                });
        }
    }
}