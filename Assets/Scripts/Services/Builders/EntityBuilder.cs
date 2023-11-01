using ECS.Components;
using Leopotam.Ecs;
using Logics.Views;
using UnityEngine;

namespace Services.Builders
{
    public class EntityBuilder
    {
        private readonly EntityConfig _config;

        protected EcsWorld World;
        protected EcsEntity Entity;
        protected EntityView EntityView;

        private Vector3 _spawnPosition;
        private Quaternion _spawnRotation;

        public EntityBuilder(EntityConfig config)
        {
            _config = config;
        }

        public void SetWorld(EcsWorld world) => World = world;

        public void SetSpawnPosition(Vector3 spawnPosition) => _spawnPosition = spawnPosition;
        public void SetSpawnRotation(Quaternion spawnRotation) => _spawnRotation = spawnRotation;

        public virtual void Make()
        {
            Entity = World.NewEntity();
            EntityView = Object.Instantiate(_config.EntityPrefab, _spawnPosition, _spawnRotation);

            EntityView.Init(World, in Entity);

            ref var description = ref Entity.Get<EntityDescription_Component>();
            description.Name = _config.Name;
            description.Description = _config.Description;
            description.Avatar = _config.Avatar;
        }

        public ref EcsEntity GetResult()
        {
            return ref Entity;
        }
    }
}