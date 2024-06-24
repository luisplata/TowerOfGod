using System;
using Unity.Entities;
using UnityEngine;

namespace Bellseboss.TowerDefenderMassive.Scripts.Player
{
    class PointToSpawnPlayerBaker : MonoBehaviour
    {
        public GameObject basePlayerPrefab;
    }

    class PointToSpawnPlayerBakerBaker : Baker<PointToSpawnPlayerBaker>
    {
        public override void Bake(PointToSpawnPlayerBaker authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
        
            AddComponent(entity, new PointToSpawnPlayer
            {
                basePlayerPrefab = GetEntity(authoring.basePlayerPrefab, TransformUsageFlags.Dynamic)
            });
            AddComponent(entity, new PlayerComponent
            {
                
                guid = Guid.NewGuid().GetHashCode(),
                isPrefabInstantiated = false
            });
        }
    }
}