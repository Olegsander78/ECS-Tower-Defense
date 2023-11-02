using Services.PlayerInput;
using Services.ServiceManager;
using UnityEngine;

namespace Logics.CameraHandler
{
    public class CameraMovement : MonoBehaviour, IInjectServices
    {
        [SerializeField] private float _raycastDistance;
        [SerializeField] private float _minDistanceToMove;
        [SerializeField] private float _sensitivity;

        [Header("Component's references")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _rootTransform;
                
        private IInputHandler _inputHandler;

        private Vector3 _planePosition;
        private Plane _plane;
        private Vector3 _startPoint;
        private Vector3 _endPoint;
        private Vector3 _newPosition;

        public void Inject(IServiceLocator locator)
        {
            _inputHandler = locator.GetService<IInputHandler>();
        }

        private void Start()
        {
            _camera ??= Camera.main;
            _rootTransform ??= _camera.transform;

            _minDistanceToMove *= _minDistanceToMove;

            _planePosition = _rootTransform.position;
            _planePosition.y -= _raycastDistance;

            _plane = new Plane(Vector3.up, _planePosition);
        }

        private void Update()
        {
            if (_inputHandler == null)
                return;

            if (_inputHandler.OnMiddleMouseButtonDown())
            {
                Ray ray = _camera.ScreenPointToRay(_inputHandler.GetMousePosition());
                if(_plane.Raycast(ray, out float enter))
                {
                    _startPoint = ray.GetPoint(enter);
                }
            }

            if (_inputHandler.OnMiddleMouseButton())
            {
                Ray ray = _camera.ScreenPointToRay(_inputHandler.GetMousePosition());
                if (_plane.Raycast(ray, out float enter))
                {
                    _endPoint = ray.GetPoint(enter);

                    var direction = _startPoint - _endPoint;

                    _newPosition = _rootTransform.position + direction;

                }
            }
        }
        private void LateUpdate()
        {
            float distance = (_startPoint - _endPoint).sqrMagnitude;

            if(distance > _minDistanceToMove)
            {
                _rootTransform.position = Vector3.MoveTowards(_rootTransform.position, _newPosition, _sensitivity);
            }
        }

    }
}