using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class ReadInputSystem : SystemBase
{
    private InputToProject _inputToProject;
    
    protected override void OnCreate()
    {
        _inputToProject = new InputToProject();
    }
    
    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        _inputToProject.Enable();
        
        _inputToProject.Player.Jump.performed += ctx =>
        {
            var jumpInput = new JumpInputComponent
            {
                isJumping = !SystemAPI.GetSingleton<JumpInputComponent>().isJumping
            };
            SystemAPI.SetSingleton(jumpInput);
        };
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();
        _inputToProject.Disable();
    }

    protected override void OnUpdate()
    {
        var moveInput = _inputToProject.Player.Move.ReadValue<Vector2>();
        
        SystemAPI.SetSingleton(new MoveInputComponent { InputMovement = moveInput});
    }
}
