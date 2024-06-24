using Unity.Entities;
using Unity.Mathematics;

public struct Cube : IComponentData
{
    public float3 direction;
    
    public float speed;
}
