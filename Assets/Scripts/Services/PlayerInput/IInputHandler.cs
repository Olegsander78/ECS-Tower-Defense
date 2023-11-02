using UnityEngine;

namespace Services.PlayerInput
{
    public interface IInputHandler
    {
        Vector3 GetMousePosition();
        bool OnLeftMouseButtonDown();
        bool OnMiddleMouseButton();
        bool OnMiddleMouseButtonDown();
        bool OnRightMouseButtonDown();
    }
}