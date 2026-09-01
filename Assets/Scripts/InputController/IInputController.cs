using UnityEngine;

namespace PlatformerTest.InputController
{
    public interface IInputController
    {
        Vector2 GetMovementInput();
        bool GetSprintInput();
        bool GetJumpInput();
    }
}
