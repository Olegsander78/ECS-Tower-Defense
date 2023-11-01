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

        public Quaternion GetTravaledRotation(float travaledTime)
        {
            return _pathCreator.path.GetRotationAtDistance(travaledTime);
        }
    }
}