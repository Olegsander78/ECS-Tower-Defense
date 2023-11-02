using PathCreation;
using UnityEngine;

namespace Services.Storages
{
    public class PathStorage : MonoBehaviour
    {
        [SerializeField] private PathCreator _pathCreator;

        public Vector3 GetTravaledDistance(float travaledTime)
        {
            return _pathCreator.path.GetPointAtDistance(travaledTime);
        }

        public bool IsEndTravaledDistance(float travaledTime)
        {
            return travaledTime >= _pathCreator.path.length;
        }

        public float GetPathLength() => _pathCreator.path.length;

        public Quaternion GetTravaledRotation(float travaledTime)
        {
            return _pathCreator.path.GetRotationAtDistance(travaledTime);
        }
    }
}