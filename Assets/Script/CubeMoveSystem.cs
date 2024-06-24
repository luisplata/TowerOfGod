using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct CubeMoveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityManager entityManager = state.EntityManager;

        NativeArray<Entity> entities = entityManager.GetAllEntities();

        foreach (var entity in entities)
        {
            if (entityManager.HasComponent<Cube>(entity))
            {
                Cube cube = entityManager.GetComponentData<Cube>(entity);

                LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(entity);
                
                float3 moveDirection = cube.direction * cube.speed * SystemAPI.Time.DeltaTime;
                
                localTransform.Position += moveDirection;
                
                entityManager.SetComponentData(entity, localTransform);

                if (cube.speed > 0)
                {
                    cube.speed -= 1f * SystemAPI.Time.DeltaTime;
                }
                else
                {
                    cube.speed = 0;
                }
                
                entityManager.SetComponentData(entity, cube);
            }
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
