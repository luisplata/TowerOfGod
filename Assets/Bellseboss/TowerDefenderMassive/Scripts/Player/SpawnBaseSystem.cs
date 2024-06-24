using Bellseboss.TowerDefenderMassive.Scripts.Enemies;
using Bellseboss.TowerDefenderMassive.Scripts.Player;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

partial struct SpawnBaseSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);
        //foreach (var (point, enemyComponent) in SystemAPI.Query<RefRW<PointToSpawnEnemy>, RefRW<EnemyComponent>>().WithAll<LocalTransform>())
        foreach (var (point, local, enemyComponent) in SystemAPI.Query<RefRW<PointToSpawnEnemy>, RefRW<LocalTransform>, RefRW<EnemyComponent>>().WithAll<EnemyComponent>())
        {
            if (!enemyComponent.ValueRO.isPrefabInstantiated)
            {
                var baseEntity = ecb.Instantiate(point.ValueRO.baseEnemyPrefab);
                
                ecb.SetComponent(baseEntity, new LocalTransform
                {
                    Position = local.ValueRO.Position,
                    Rotation = local.ValueRO.Rotation,
                    Scale = local.ValueRO.Scale
                });
                
                enemyComponent.ValueRW.isPrefabInstantiated = true;
            }
        }
        
        
        foreach (var (point, playerComponent, localTransform) in SystemAPI.Query<RefRO<PointToSpawnPlayer>, RefRW<PlayerComponent>, RefRW<LocalTransform>>())
        {
            if (!playerComponent.ValueRO.isPrefabInstantiated)
            {
                playerComponent.ValueRW.isPrefabInstantiated = true;
                
                Entity baseEntity = ecb.Instantiate(point.ValueRO.basePlayerPrefab);
                
                ecb.SetComponent(baseEntity, new LocalTransform
                {
                    Position = localTransform.ValueRO.Position,
                    Rotation = localTransform.ValueRO.Rotation,
                    Scale = localTransform.ValueRO.Scale
                });
            }
        }
        
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
    
}
