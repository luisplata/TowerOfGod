using Unity.Entities;

namespace Bellseboss.TowerDefenderMassive.Scripts.Enemies
{
    public struct PointToSpawnEnemy : IComponentData
    {
        public Entity baseEnemyPrefab;
    }
}
