using Unity.Entities;

namespace Bellseboss.TowerDefenderMassive.Scripts.Player
{
    public struct PlayerComponent : IComponentData
    {
        public int guid;
        public bool isPrefabInstantiated;
    }
}
