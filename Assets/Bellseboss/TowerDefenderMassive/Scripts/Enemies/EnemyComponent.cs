using Unity.Entities;

namespace Bellseboss.TowerDefenderMassive.Scripts.Enemies
{
    public struct EnemyComponent : IComponentData
    {
        public int guid;
        public bool isPrefabInstantiated;
    }
}
