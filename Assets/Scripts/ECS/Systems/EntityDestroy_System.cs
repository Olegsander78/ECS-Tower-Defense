using ECS.Components;
using ECS.Marks;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace ECS.Systems
{
    public class EntityDestroy_System : IEcsRunSystem
    {
        private EcsFilter<EntityDestroy_Mark> _destroyFilter;
        public void Run()
        {
            foreach (var item in _destroyFilter)
            {
                ref var entity = ref _destroyFilter.GetEntity(item);

                if (entity.Has<Transform_Component>())
                {
                    ref var transformComponent = ref entity.Get<Transform_Component>();
                    Object.Destroy(transformComponent.Transform.gameObject);
                }

                entity.Destroy();
            }
        }
    }
}