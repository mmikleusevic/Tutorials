using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpawnerEntity>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var prefab = SystemAPI.GetSingleton<SpawnerEntity>().CubePrefab;
        var instances = state.EntityManager.Instantiate(prefab, 10, Allocator.Temp);

        var random = new Random(123);
        foreach (var entity in instances)
        {
            var transform = SystemAPI.GetComponentRW<LocalTransform>(entity);
            transform.ValueRW.Position = random.NextFloat3(new float3(random.NextFloat(0,10), random.NextFloat(0, 10), random.NextFloat(0, 10)));
        }
    }
}