using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlatformerTest.Impl.Processors
{
    public sealed class PlayerInputProcessor : IInputProcessor
    {
        private const string MoveActionName = "Move";
        private const string SprintActionName = "Sprint";
        private const string JumpActionName = "Jump";
 
        private readonly InputActionMap _map;
        private readonly InputAction _moveAction;
        private readonly InputAction _sprintAction;
        private readonly InputAction _jumpAction;
 
        public PlayerInputProcessor(InputActionMap map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
 
            _moveAction = _map.FindAction(MoveActionName)
                          ?? throw new ArgumentNullException(nameof(_moveAction), $"Action '{MoveActionName}' not found in map '{_map.name}'.");
            _sprintAction = _map.FindAction(SprintActionName)
                            ?? throw new ArgumentNullException(nameof(_sprintAction), $"Action '{SprintActionName}' not found in map '{_map.name}'.");
            _jumpAction = _map.FindAction(JumpActionName)
                          ?? throw new ArgumentNullException(nameof(_jumpAction), $"Action '{JumpActionName}' not found in map '{_map.name}'.");
        }
 
        public void Enable() => _map.Enable();
 
        public void Disable() => _map.Disable();
 
        public Vector2 GetMovementInput() => _moveAction.ReadValue<Vector2>();
 
        public bool GetSprintInput() => _sprintAction.IsPressed();
 
        public bool GetJumpInput() => _jumpAction.WasPressedThisFrame();
    }
}