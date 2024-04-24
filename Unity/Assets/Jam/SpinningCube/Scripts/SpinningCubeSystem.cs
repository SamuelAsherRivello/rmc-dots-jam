using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct SpinningCubeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpinningCubeComponent>();
    }

    public void OnUpdate(ref SystemState state)
    {
        //find all the cubes, spin them
        foreach (var (localTransform, spinningCubeComponent) in
                 SystemAPI.Query<    RefRW<LocalTransform>, RefRO<SpinningCubeComponent>     >())
        {
            //move
            var r = quaternion.Euler(
                spinningCubeComponent.ValueRO.Speed.x * SystemAPI.Time.DeltaTime,
                spinningCubeComponent.ValueRO.Speed.y * SystemAPI.Time.DeltaTime,
                spinningCubeComponent.ValueRO.Speed.z * SystemAPI.Time.DeltaTime);

            localTransform.ValueRW = localTransform.ValueRW.Rotate(r);
        }
    }
}