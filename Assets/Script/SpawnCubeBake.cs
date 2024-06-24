using Unity.Entities;
using UnityEngine;

class SpawnCubeBake : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;
}

class SpawnCubeBakeBaker : Baker<SpawnCubeBake>
{
    public override void Bake(SpawnCubeBake authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new SpawnCube
        {
            prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            spawnPosition = authoring.transform.position,
            nextSpawnTime = 0,
            sawpRate = authoring.spawnRate
        });
    }
}
