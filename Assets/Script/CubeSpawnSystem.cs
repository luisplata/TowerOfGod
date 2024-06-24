using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

partial struct CubeSpawnSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if(!SystemAPI.TryGetSingletonEntity<SpawnCube>(out Entity cubeEntity))
        {
            return;
        }
        RefRW<SpawnCube> cubeSpawn = SystemAPI.GetComponentRW<SpawnCube>(cubeEntity);

        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

        if (cubeSpawn.ValueRO.nextSpawnTime < SystemAPI.Time.ElapsedTime)
        {
            Entity newEntity = ecb.Instantiate(cubeSpawn.ValueRO.prefab);
            
            ecb.AddComponent(newEntity, new Cube
            {
                direction = Random.CreateFromIndex((uint)(SystemAPI.Time.ElapsedTime / SystemAPI.Time.DeltaTime)).NextFloat3(), 
                speed = 10
            });
            
            cubeSpawn.ValueRW.nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + cubeSpawn.ValueRO.sawpRate;
            
            ecb.Playback(state.EntityManager);
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
