using Unity.Burst;
using Unity.Entities;
using UnityEngine;

partial struct ReadMoveAndJumpSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (move, jump) in SystemAPI.Query<RefRO<MoveInputComponent>, RefRO<JumpInputComponent>>())
        {
            //Debug.Log(move.ValueRO.InputMovement);
            //Debug.Log(jump.ValueRO.isJumping);
        }

        foreach (var moveInputComponent in SystemAPI.Query<RefRO<MoveInputComponent>>())
        {
            //Debug.Log($"Movement: {moveInputComponent.ValueRO.InputMovement}");
        }

        foreach (var jumpInputComponent in SystemAPI.Query<RefRO<JumpInputComponent>>())
        {
            //Debug.Log($"Jumping: {jumpInputComponent.ValueRO.isJumping}");
        }
    }
}