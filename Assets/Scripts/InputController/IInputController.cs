using UnityEngine;

namespace PlatformerTest
{
    public interface IInputController
    {
        Vector2 GetMovementInput();
        bool GetSprintInput();
        bool GetJumpInput();
    }
}
