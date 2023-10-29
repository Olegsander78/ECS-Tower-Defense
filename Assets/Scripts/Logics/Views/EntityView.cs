using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logics.Views
{
    public class EntityView : MonoBehaviour
    {
        [field: SerializeField] public Transform SelfTransform { get; private set; }

        private EcsEntity _entity;

        public void Init(EcsWorld world, in EcsEntity entity)
        {
            _entity = entity;
        }
    }
}