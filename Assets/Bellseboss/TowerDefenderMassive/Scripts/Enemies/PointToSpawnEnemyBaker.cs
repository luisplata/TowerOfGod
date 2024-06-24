using System;
using Unity.Entities;
using UnityEngine;

namespace Bellseboss.TowerDefenderMassive.Scripts.Enemies
{
    class PointToSpawnEnemyBaker : MonoBehaviour
    {
        public GameObject baseEnemyPrefab;
    }

    class PointToSpawnEnemyBakerBaker : Baker<PointToSpawnEnemyBaker>
    {
        public override void Bake(PointToSpawnEnemyBaker authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
        
            AddComponent(entity, new PointToSpawnEnemy
            {
                baseEnemyPrefab = GetEntity(authoring.baseEnemyPrefab, TransformUsageFlags.Dynamic)
            });
            
            AddComponent(entity, new EnemyComponent
            {
                guid = Guid.NewGuid().GetHashCode(),
                isPrefabInstantiated = false
            });
        }
    }
}