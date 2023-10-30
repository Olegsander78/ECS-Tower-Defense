using Leopotam.Ecs;
using UnityEngine;

namespace Logics.Views
{
    public class EntityView : MonoBehaviour
    {
        [field: SerializeField] public Transform SelfTransform { get; private set; }

        private EcsWorld _world;
        private EcsEntity _entity;

        public void Init(EcsWorld world, in EcsEntity entity)
        {
            _world = world;
            _entity = entity;
        }
    }
}