using Unity.Entities;
using Unity.Mathematics;

public struct SpawnCube : IComponentData
{
    public Entity prefab;
    public float3 spawnPosition;
    public float nextSpawnTime;
    public float sawpRate;
}
