using Unity.Entities;
using UnityEngine;

class InputPlayerBaker : MonoBehaviour
{
    
}

class PlayerBakerBaker : Baker<InputPlayerBaker>
{
    public override void Bake(InputPlayerBaker authoring)
    {
        var playerEntity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent<MoveInputComponent>(playerEntity);
        AddComponent<JumpInputComponent>(playerEntity);
    }
}
