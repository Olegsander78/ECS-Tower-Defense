using Leopotam.Ecs;
using Services.Builders;
using Services.ServiceManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Factory
{
    public class EntityFactory : IEntityFactory
    {
        private readonly EcsWorld _world;
        private readonly IServiceLocator _serviceLocator;

        public EntityFactory(EcsWorld world, IServiceLocator serviceLocator)
        {
            _world = world;
            _serviceLocator = serviceLocator;
        }

        public ref EcsEntity CreateEntity(EntityBuilder builder, Vector3 position, Quaternion rotation = default)
        {
            builder.SetWorld(_world);
            builder.SetSpawnPosition(position);
            builder.SetSpawnRotation(rotation);

            builder.Make();

            return ref builder.GetResult();
        }
    }
}