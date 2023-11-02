using UnityEngine;

namespace Services.PlayerInput
{
    public class InputHandler : IInputHandler
    {
        public Vector3 GetMousePosition() => Input.mousePosition;
        public bool OnLeftMouseButtonDown() => Input.GetMouseButtonDown(0);
        public bool OnMiddleMouseButtonDown() => Input.GetMouseButtonDown(2);
        public bool OnMiddleMouseButton() => Input.GetMouseButton(2);
        public bool OnRightMouseButtonDown() => Input.GetMouseButtonDown(1);

    }
}