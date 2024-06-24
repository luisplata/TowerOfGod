using Unity.Entities;

namespace Bellseboss.TowerDefenderMassive.Scripts.Player
{
    public struct PointToSpawnPlayer : IComponentData
    {
        public Entity basePlayerPrefab;
    }
}
